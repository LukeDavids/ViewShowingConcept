using System.Collections.Generic;
using System.Linq;
using Android.App;
using Android.OS;
using Java.Lang;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Droid.Support.V7.Fragging.Fragments;
using MvvmCross.Droid.Views;
using MvvmCross.Platform;
using ViewShowingConcept.Android.Views.Base;
using ViewShowingConcept.Core.Enums;
using ViewShowingConcept.Core.Models;
using ViewShowingConcept.Core.ViewModels;

namespace ViewShowingConcept.Android.Views
{
    [Activity(Label = "View for ContainerView", Theme = "@style/AppTheme", MainLauncher = true)]
    public class ContainerView : MvxCachingFragmentCompatActivity
    {

        private CustomerListFragment _customerListFragment;
        private CustomerDetailFragment _customerDetailFragment;
        private CustomerEditFragment _customerEditFragment;
        private LoginFragment _loginFragment;

        public Dictionary<SubView, BaseView> SubViews { get; set; }
        public string CurrentCustomerId { get; set; }

        public ContainerViewModel ContainerViewModel
        {
            get { return (ContainerViewModel) ContainerViewModel; }
            set { ViewModel = value; }
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.ContainerView);

            _customerListFragment = new CustomerListFragment
            {
                ViewModel = ContainerViewModel.CustomerListViewModel
            };
            _customerDetailFragment = new CustomerDetailFragment
            {
                ViewModel = ContainerViewModel.CustomerDetailViewModel
            };
            _customerEditFragment = new CustomerEditFragment
            {
                ViewModel = ContainerViewModel.CustomerEditViewModel
            };
            _loginFragment = new LoginFragment
            {
                ViewModel = ContainerViewModel.LoginViewModel
            };

            SetupBindings();
            SetupSubViews();
            AddFragments();
            ShowFragment(_loginFragment, "customerList");
        }

        private SubView _currentSubView;
        public SubView CurrentSubView
        {
            get { return _currentSubView; }
            set
            {
                _currentSubView = value;
                ShowFragment(SubViews[_currentSubView], _currentSubView.ToString());
            }
        }

        private void SetupSubViews()
        {
            SubViews = new Dictionary<SubView, BaseView>
            {
                {SubView.Login, new LoginFragment {ViewModel = ContainerViewModel.LoginViewModel} },
                {SubView.CustomerDetails, new CustomerDetailFragment {ViewModel = ContainerViewModel.CustomerDetailViewModel} },
                {SubView.CustomerEdit, new CustomerEditFragment {ViewModel = ContainerViewModel.CustomerEditViewModel} },
                {SubView.CustomerList, new CustomerListFragment {ViewModel = ContainerViewModel} }
            };
        }

        public void ShowFragment(BaseView fragment, string tag)
        {
            //FlushFragments();
            var fragmentTransaction = SupportFragmentManager.BeginTransaction();
            SupportFragmentManager.ExecutePendingTransactions();
            HideFragments();

            try
            {
                //fragment.BaseViewModel.Init(CurrentCustomerId);
                fragmentTransaction.Replace(Resource.Id.content_frame, fragment, tag);
                fragment.SetMenuVisibility(true);
            }
            catch (Exception e)
            {
                AddFragments();
                fragmentTransaction.Replace(Resource.Id.content_frame, fragment, tag);
                fragment.SetMenuVisibility(true);
            }

            fragmentTransaction.Commit();
        }

        public void FlushFragments()
        {
            var fragmentTransaction =SupportFragmentManager.BeginTransaction();

            foreach (var baseView in SubViews.Where(baseView => baseView.Value != null))
            {
                fragmentTransaction.Remove(baseView.Value);
            }

            fragmentTransaction.Commit();
        }

        public void HideFragments()
        {
            foreach (var baseView in SubViews)
            {
                baseView.Value.SetMenuVisibility(false);
            }
        }

        public void AddFragments()
        {
            var fragmentTransaction = SupportFragmentManager.BeginTransaction();

            fragmentTransaction.Add(Resource.Id.content_frame, SubViews[SubView.CustomerList], "customerListFragment");

            fragmentTransaction.Commit();
        }

        public bool BackPressedOnListView()
        {
            if (SubViews[SubView.CustomerList].IsMenuVisible)
            {
                //OnDestroyView();
                return true;
            }
            foreach (var baseView in SubViews.Where(baseView => baseView.Value.IsVisible))
            {
                ShowFragment(baseView.Value, baseView.Value.SubViewType.ToString());
                return false;
            }
            return true;
        }

        private void SetupBindings()
        {
            this.CreateBinding(this)
                .For(view => view.CurrentSubView)
                .To<CustomerListViewModel>(vm => vm.CurrentSubView)
                .Apply();
            this.CreateBinding(this)
                .For(view => view.CurrentCustomerId)
                .To<ContainerViewModel>(vm => vm.CustomerId)
                .Apply();
        }
    }
}