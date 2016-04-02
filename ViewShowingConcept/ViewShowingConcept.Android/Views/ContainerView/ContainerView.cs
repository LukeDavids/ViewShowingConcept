using System.Collections.Generic;
using System.Linq;
using Android.App;
using Android.OS;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Droid.Support.V7.Fragging.Fragments;
using ViewShowingConcept.Core.Enums;
using ViewShowingConcept.Core.ViewModels;
using ViewShowingConcept.Core.ViewModels.Container;
using IAndroidSubView = ViewShowingConcept.Android.Interfaces.IAndroidSubView;

namespace ViewShowingConcept.Android.Views.ContainerView
{
    [Activity(Label = "View for ContainerView", Theme = "@style/AppTheme", MainLauncher = true)]
    public class ContainerView : MvxCachingFragmentCompatActivity
    {
        public Dictionary<ViewType, IAndroidSubView> Views { get; set; }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.ContainerView);
            SetupBindings();
            SetupViews();
            AddFragments();
            CurrentView = ViewType.CustomerDetails;
        }

        private ViewType _currentView;
        public ViewType CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                ShowFragment(Views[_currentView]);
            }
        }

        private void SetupViews()
        {
            Views = new Dictionary<ViewType, IAndroidSubView>
            {
                {ViewType.Login, new LoginView(ViewType.Login) },
                {ViewType.CustomerDetails, new CustomerDetailView(ViewType.CustomerDetails) },
                {ViewType.CustomerEdit, new CustomerEditView(ViewType.CustomerEdit) },
                {ViewType.CustomerList, new CustomerListView(ViewType.CustomerList) }
            };
        }

        public void ShowFragment(IAndroidSubView androidSubView)
        {
            //FlushFragments();
            var fragmentTransaction = SupportFragmentManager.BeginTransaction();
            SupportFragmentManager.ExecutePendingTransactions();
            HideFragments();

            try
            {
                fragmentTransaction.Replace(Resource.Id.content_frame, androidSubView.Fragment, androidSubView.SubViewTag);
                androidSubView.Fragment.SetMenuVisibility(true);
            }
            catch (System.Exception e)
            {
                AddFragments();
                fragmentTransaction.Replace(Resource.Id.content_frame, androidSubView.Fragment, androidSubView.SubViewTag);
                androidSubView.Fragment.SetMenuVisibility(true);
            }

            fragmentTransaction.Commit();
        }

        public void FlushFragments()
        {
            var fragmentTransaction =SupportFragmentManager.BeginTransaction();

            foreach (var baseView in Views.Where(baseView => baseView.Value != null))
            {
                fragmentTransaction.Remove((MvxFragment) baseView.Value);
            }

            fragmentTransaction.Commit();
        }

        public void HideFragments()
        {
            foreach (var subview in Views)
            {
                subview.Value.Fragment.SetMenuVisibility(false);
            }
        }

        public void AddFragments()
        {
            var fragmentTransaction = SupportFragmentManager.BeginTransaction();

            fragmentTransaction.Add(Resource.Id.content_frame, Views[ViewType.Login].Fragment, Views[ViewType.Login].SubViewTag);

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
                .For(view => view.CurrentView)
                .To<ContainerViewModel>(vm => vm.CurrentView)
                .Apply();
            
        }
    }
}