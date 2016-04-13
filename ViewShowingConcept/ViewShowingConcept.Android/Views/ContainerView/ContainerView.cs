using System.Collections.Generic;
using System.Linq;
using Android.App;
using Android.OS;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Droid.Support.V7.AppCompat;
using ViewShowingConcept.Core.Enums;
using ViewShowingConcept.Core.Models;
using ViewShowingConcept.Core.ViewModels.Container;
using IAndroidView = ViewShowingConcept.Android.Interfaces.IAndroidView;
using static ViewShowingConcept.Core.Enums.ViewType;
using static ViewShowingConcept.Core.Enums.ViewFrame;

namespace ViewShowingConcept.Android.Views.ContainerView
{
    [Activity(Label = "ViewShowingConcept", Theme = "@style/AppTheme", MainLauncher = true)]
    public class ContainerView : MvxCachingFragmentCompatActivity<ContainerViewModel>
    {
        public Dictionary<ViewType, IAndroidView> Views { get; set; }
        public Dictionary<ViewFrame, int> ViewFrames { get; set; }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetupBindings();
            SetupViews();
            SetContentView(Resource.Layout.ContainerView);
            SetupContentFrames();
            ShowViewEvent = new ShowViewEvent(ViewType.TabbedView, FullScreen, "");
        }

        private void SetupContentFrames()
        {
            ViewFrames = new Dictionary<ViewFrame, int>
            {
                [FullScreen]        = Resource.Id.content_frame,
                [FullScreenTabs]    = Resource.Id.viewpager,
                [HalfScreenTop]     = Resource.Id.list_frame,
                [HalfScreenBottom]  = Resource.Id.view_frame,
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
                ShowView(_showViewEvent);
            }
        }
        
        private void SetupViews()
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
                {ViewType.DummyTab2View,    new DummyTab2View()}
            };
        }

        public void ShowView(ShowViewEvent showViewEvent)
        {
            var view = Views[showViewEvent.ViewType];
            var viewFrame = ViewFrames[showViewEvent.ViewFrame];
            var viewFragment = view.Fragment;
            var viewTag = view.ViewTag;
            var fragmentTransaction = SupportFragmentManager.BeginTransaction();

            SupportFragmentManager.ExecutePendingTransactions();
            HideFragments();
            
            try
            {
                view.BaseViewModel.InitialiseCommand.Execute(showViewEvent);
                fragmentTransaction.Replace(viewFrame, viewFragment, viewTag);
                view.Fragment.SetMenuVisibility(true);
            }
            catch (System.Exception e)
            {
                view.BaseViewModel.InitialiseCommand.Execute(showViewEvent);
                AddFragments(showViewEvent);
                view.Fragment.SetMenuVisibility(true);
            }

            fragmentTransaction.Commit();
        }

        public void FlushFragments()
        {
            var fragmentTransaction =SupportFragmentManager.BeginTransaction();

            foreach (var view in Views.Where(baseView => baseView.Value != null))
            {
                fragmentTransaction.Remove(view.Value.Fragment);
            }

            fragmentTransaction.Commit();
        }

        public void HideFragments()
        {
            foreach (var view in Views)
            {
                view.Value.Fragment.SetMenuVisibility(false);
            }
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
    }
}