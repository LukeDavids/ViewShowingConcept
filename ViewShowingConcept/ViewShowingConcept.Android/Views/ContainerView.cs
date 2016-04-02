using System;
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
using MvvmCross.Platform;
using ViewShowingConcept.Android.Views.Base;
using IAndroidSubView = ViewShowingConcept.Android.Interfaces.IAndroidSubView;

namespace ViewShowingConcept.Android.Views
{
    [Activity(Label = "View for ContainerView", Theme = "@style/AppTheme", MainLauncher = true)]
    public class ContainerView : MvxCachingFragmentCompatActivity
    {
        public Dictionary<SubViewType, IAndroidSubView> SubViews { get; set; }
        public string CurrentCustomerId { get; set; }
        

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.ContainerView);
            SetupBindings();
            SetupSubViews();
            AddFragments();
            ShowFragment(SubViews[SubViewType.Login]);
        }

        private SubViewType _currentSubView;
        public SubViewType CurrentSubView
        {
            get { return _currentSubView; }
            set
            {
                _currentSubView = value;
                ShowFragment(SubViews[_currentSubView]);
            }
        }

        private void SetupSubViews()
        {
            SubViews = new Dictionary<SubViewType, IAndroidSubView>
            {
                {SubViewType.Login, new LoginSubSubView(SubViewType.Login) },
                {SubViewType.CustomerDetails, new CustomerDetailSubSubView(SubViewType.CustomerDetails) },
                {SubViewType.CustomerEdit, new CustomerEditSubSubView(SubViewType.CustomerEdit) },
                {SubViewType.CustomerList, new CustomerListSubSubView(SubViewType.CustomerList) }
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

            fragmentTransaction.Add(Resource.Id.content_frame, SubViews[SubViewType.Login].Fragment, SubViews[SubViewType.Login].SubViewTag);

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