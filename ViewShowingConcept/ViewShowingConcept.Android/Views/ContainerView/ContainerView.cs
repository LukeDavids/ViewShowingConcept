using System.Collections.Generic;
using System.Linq;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Util;
using Android.Views;
using Android.Widget;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Platform;
using ViewShowingConcept.Core.Enums;
using ViewShowingConcept.Core.Models;
using ViewShowingConcept.Core.ViewModels.Container;
using IAndroidView = ViewShowingConcept.Android.Interfaces.IAndroidView;
using static ViewShowingConcept.Core.Enums.ViewType;
using static ViewShowingConcept.Core.Enums.ViewFrame;
using System;
using Android.Support.V4.View;

namespace ViewShowingConcept.Android.Views.ContainerView
{
    [Activity(Label = "ViewShowingConcept", Theme = "@style/AppTheme", MainLauncher = true)]
    public class ContainerView : MvxCachingFragmentCompatActivity<ContainerViewModel>
    {
        public Dictionary<ViewType, IAndroidView> Views { get; set; }
        public Dictionary<ViewFrame, int> ViewFrames { get; set; }
        private ViewType CurrentFragment { get; set; }
        public ViewType PreviousFragment { get; set; }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetupViews();
            SetupBindings();
            SetContentView(Resource.Layout.ContainerView);
            SetupContentFrames();
            Mvx.RegisterSingleton(() => this);
            ShowViewEvent = new ShowViewEvent(ViewType.TabbedView, FullScreen, "");

        }

        private void SetupContentFrames()
        {
            ViewFrames = new Dictionary<ViewFrame, int>
            {
                [FullScreen]        = Resource.Id.content_frame,
                [FullScreenTabs]    = Resource.Id.tabcontent,
                [HalfScreenTop]     = Resource.Id.list_frame,
                [Detail]            = Resource.Id.view_frame,
                [TabContents]       = Resource.Id.tab_content_frame
            };
            //Add more so we can replace different areas of the screen
        }

        private ShowViewEvent _showViewEvent;
        public ShowViewEvent ShowViewEvent
        {
            get { return _showViewEvent; }
            set
            {
                _showViewEvent = value;
                if(value != null)
                ShowView(_showViewEvent);
            }
        }
        
        public void SetupViews()
        {
            Views = new Dictionary<ViewType, IAndroidView>
            {
                {CustomerDetails,           new CustomerDetailView()},
                {CustomerEdit,              new CustomerEditView()},
                {CustomerList,              new CustomerListView()},
                {ViewType.CustomerView,     new CustomerView()},
                {CustomerSplit,             new CustomerSplitView()},
                {ViewType.TabbedView,       new TabbedView()},
                {ViewType.DummyTab1View,    new DummyTab1View()},
                {ViewType.DummyTab2View,    new DummyTab2View()},
                {ViewType.DummyTab3View,    new DummyTab3View()}
            };
        }

        public void ShowView(ShowViewEvent showViewEvent)
        {
            var view = Views[showViewEvent.ViewType];
            var viewFrame = ViewFrames[showViewEvent.ViewFrame];
            var viewFragment = view.Fragment;
            var viewTag = view.ViewTag;
            var fragmentTransaction = SupportFragmentManager.BeginTransaction();
            try
            {
                view.BaseViewModel.InitialiseCommand.Execute(showViewEvent);
                fragmentTransaction.Replace(viewFrame, viewFragment, viewTag);
                view.Fragment.SetMenuVisibility(true);

                if (!CurrentFragment.Equals(view.ViewType) && !view.ViewType.Equals(ViewType.TabbedView) && !view.ViewType.Equals(ViewType.CustomerList) && !view.ViewType.Equals(ViewType.CustomerSplit))
                {
                    switch (TabbedView.CurrentTab)
                    {
                        case Tabs.CustomersTab:
                            ContainerViewModel.CustomersBackStack.Push(showViewEvent);
                            break;
                        case Tabs.Dummy1Tab:
                            ContainerViewModel.DummyTab1BackStack.Push(showViewEvent);
                            break;
                        case Tabs.Dummy2Tab:
                            ContainerViewModel.DummyTab2BackStack.Push(showViewEvent);
                            break;
                        case Tabs.Dummy3Tab:
                            ContainerViewModel.DummyTab3BackStack.Push(showViewEvent);
                            break;
                    }
                }

            }
            catch (System.Exception e)
            {
                view.BaseViewModel.InitialiseCommand.Execute(showViewEvent);
                AddFragments(showViewEvent);
                view.Fragment.SetMenuVisibility(true);

                if (!CurrentFragment.Equals(view.ViewType) && !view.ViewType.Equals(ViewType.TabbedView) && !view.ViewType.Equals(ViewType.CustomerList) && !view.ViewType.Equals(ViewType.CustomerSplit))
                {
                    switch (TabbedView.CurrentTab)
                    {
                        case Tabs.CustomersTab:
                            ContainerViewModel.CustomersBackStack.Push(showViewEvent);
                            break;
                        case Tabs.Dummy1Tab:
                            ContainerViewModel.DummyTab1BackStack.Push(showViewEvent);
                            break;
                        case Tabs.Dummy2Tab:
                            ContainerViewModel.DummyTab2BackStack.Push(showViewEvent);
                            break;
                        case Tabs.Dummy3Tab:
                            ContainerViewModel.DummyTab3BackStack.Push(showViewEvent);
                            break;
                    }
                }
                

                PreviousFragment = CurrentFragment;
                CurrentFragment = view.ViewType;
            }

            fragmentTransaction.Commit();
        }

        public void FlushFragments()
        {
            var fragmentTransaction = SupportFragmentManager.BeginTransaction();

            foreach (var view in Views.Where(baseView => baseView.Value != null && !baseView.Value.ViewTag.Equals(ViewType.TabbedView.ToString())))
            {
                fragmentTransaction.Remove(view.Value.Fragment);
            }

            fragmentTransaction.Commit();
        }

        public void AddFragments(ShowViewEvent showViewEvent)
        {
            var view = Views[showViewEvent.ViewType];
            var viewFrame = ViewFrames[showViewEvent.ViewFrame];
            var viewFragment = view.Fragment;
            var viewTag = view.ViewTag;
            var fragmentTransaction = SupportFragmentManager.BeginTransaction();

            fragmentTransaction.Add(viewFrame, viewFragment, viewTag);
            fragmentTransaction.Commit();
        }
        

        private void SetupBindings()
        {
            this.CreateBinding(this)
                .For(view => view.ShowViewEvent)
                .To<ContainerViewModel>(vm => vm.ShowViewEvent)
                .Apply();
        }

        public override void OnBackPressed()
        {
            FlushFragments();
            try
            {
                switch (TabbedView.CurrentTab)
                {
                    case Tabs.CustomersTab:
                        ContainerViewModel.CustomersBackStack.Pop();
                        SetupViews();
                        if(ContainerViewModel.CustomersBackStack.Last().ViewType == ViewType.CustomerList)
                            ShowView(new ShowViewEvent(CustomerSplit, FullScreenTabs, ""));
                        ShowView(ContainerViewModel.CustomersBackStack.Last());
                        break;
                    case Tabs.Dummy1Tab:
                        ContainerViewModel.DummyTab1BackStack.Pop();
                        ShowView(ContainerViewModel.DummyTab1BackStack.Last());
                        break;
                    case Tabs.Dummy2Tab:
                        ContainerViewModel.DummyTab2BackStack.Pop();
                        ShowView(ContainerViewModel.DummyTab2BackStack.Last());
                        break;
                    case Tabs.Dummy3Tab:
                        ContainerViewModel.DummyTab3BackStack.Pop();
                        ShowView(ContainerViewModel.DummyTab3BackStack.Last());
                        break;
                }
            }
            catch (Exception e) {
                base.OnBackPressed();
            }

            CurrentFragment = PreviousFragment;
        }
    }

    
}