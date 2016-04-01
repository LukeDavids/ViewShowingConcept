using System.Collections.Generic;
using System.Linq;
using Android.App;
using Android.OS;
using Java.Lang;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Droid.Support.V7.AppCompat;
using ViewShowingConcept.Core.Enums;
using ViewShowingConcept.Core.Interfaces;
using ViewShowingConcept.Core.ViewModels;
using MvvmCross.Droid.Support.V7.Fragging.Fragments;
using ViewShowingConcept.Android.Views.Base;

namespace ViewShowingConcept.Android.Views
{
    [Activity(Label = "View for ContainerView", Theme = "@style/AppTheme", MainLauncher = true)]
    public class ContainerView : MvxCachingFragmentCompatActivity
    {

        private CustomerListFragment _customerListFragment;
        private CustomerDetailFragment _customerDetailFragment;
        private CustomerEditFragment _customerEditFragment;
        private LoginFragment _loginFragment;

        public Dictionary<SubView, ISubView> SubViews { get; set; }
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

            _customerListFragment = new CustomerListFragment();
            _customerDetailFragment = new CustomerDetailFragment();
            _customerEditFragment = new CustomerEditFragment();
            _loginFragment = new LoginFragment();

            SetupBindings();
            SetupSubViews();
            AddFragments();
            ShowFragment(_loginFragment, "loginFragment");
        }

        private SubView _currentSubView;
        public SubView CurrentSubView
        {
            get { return _currentSubView; }
            set
            {
                _currentSubView = value;
                ShowFragment(SubViews[_currentSubView].Fragment, _currentSubView.ToString());
            }
        }

        private void SetupSubViews()
        {
            SubViews = new Dictionary<SubView, ISubView>
            {
                {SubView.Login, _loginFragment },
                {SubView.CustomerDetails, _customerDetailFragment },
                {SubView.CustomerEdit, _customerEditFragment },
                {SubView.CustomerList, _customerListFragment }
            };
        }

        public void ShowFragment(MvxFragment fragment, string tag)
        {
            //FlushFragments();
            var fragmentTransaction = SupportFragmentManager.BeginTransaction();
            SupportFragmentManager.ExecutePendingTransactions();
            HideFragments();

            try
            {
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
                fragmentTransaction.Remove((MvxFragment) baseView.Value);
            }

            fragmentTransaction.Commit();
        }

        public void HideFragments()
        {
            foreach (var subview in SubViews)
            {
                subview.Value.Fragment.SetMenuVisibility(false);
            }
        }

        public void AddFragments()
        {
            var fragmentTransaction = SupportFragmentManager.BeginTransaction();

            fragmentTransaction.Add(Resource.Id.content_frame, _loginFragment, "loginFragment");

            fragmentTransaction.Commit();
        }

        //public bool BackPressedOnListView()
        //{
        //    if (SubViews[SubView.CustomerList].IsMenuVisible)
        //    {
        //        //OnDestroyView();
        //        return true;
        //    }
        //    foreach (var baseView in SubViews.Where(baseView => baseView.Value.IsMenuVisible))
        //    {
        //        BaseView<> fragment = (MvxFragment) baseView.Value;
        //        ShowFragment(baseView.Value, fragment.SubViewType.ToString());
                
        //        return false;
        //    }
        //    return true;
        //}

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