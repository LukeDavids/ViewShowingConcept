using System.Collections.Generic;
using System.Linq;
using Android.App;
using Android.OS;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Droid.Support.V7.Fragging;
using ViewShowingConcept.Core.Enums;
using ViewShowingConcept.Core.Models;
using ViewShowingConcept.Core.ViewModels.Container;
using IAndroidView = ViewShowingConcept.Android.Interfaces.IAndroidView;
using static ViewShowingConcept.Core.Enums.ViewType;
using static ViewShowingConcept.Core.Enums.ViewFrame;

namespace ViewShowingConcept.Android.Views.ContainerView
{
    [Activity(Label = "ViewShowingConcept", MainLauncher = true)]
    public class ContainerView : MvxFragmentActivity
    {
        
        public Dictionary<ViewType, IAndroidView> Views { get; set; }
        public Dictionary<ViewFrame, int> ViewFrames { get; set; } 

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.ContainerView);
            SetupBindings();
            SetupViews();
            SetupContentFrames();
            AddFragments();
            ShowViewEvent = new ShowViewEvent(CustomerList, FullScreen, "");
        }

        private void SetupContentFrames()
        {
            ViewFrames = new Dictionary<ViewFrame, int>
            {
                [FullScreen] = Resource.Id.content_frame
            };
            //Add more so we can replace different areas of the screen
        }

        public ContainerViewModel ContainerViewModel => this.ViewModel as ContainerViewModel;

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
                {CustomerDetails, new CustomerDetailView() },
                {CustomerEdit, new CustomerEditView() },
                {CustomerList, new CustomerListView() },
                {ViewType.CustomerView, new CustomerView() }
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
                fragmentTransaction.AddToBackStack(viewTag);
                view.Fragment.SetMenuVisibility(true);
            }
            catch (System.Exception e)
            {
                AddFragments();
                fragmentTransaction.Replace(viewFrame, viewFragment, viewTag);
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

        public void AddFragments()
        {
            var fragmentTransaction = SupportFragmentManager.BeginTransaction();
            fragmentTransaction.Add(ViewFrames[FullScreen], Views[CustomerDetails].Fragment, Views[CustomerDetails].ViewTag);
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