using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;

using CoreFoundation;
using UIKit;
using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using MvvmCross.Platform;
using MvvmCross.Platform.Platform;
using ViewShowingConcept.Core.Enums;
using ViewShowingConcept.Core.Models;
using ViewShowingConcept.Core.ViewModels;
using ViewShowingConcept.Core.ViewModels.Base;
using ViewShowingConcept.Core.ViewModels.Container;
using ViewShowingConcept.Ios.Interfaces;
using ViewShowingConcept.Ios.Views.Base;

namespace ViewShowingConcept.Ios.Views.Container
{
    [Register("ContainerView")]
    public class ContainerView : MvxViewController<ContainerViewModel>
    {
        private UIViewController Navigator = new UINavigationController();
        public Dictionary<ViewType, IIosView> Views { get; set; }
        public Dictionary<ViewFrame, int> ViewFrames { get; set; } = new Dictionary<ViewFrame, int>()
        {
            {ViewFrame.FullScreen, 0 },
            {ViewFrame.TabContents, 1 },
            {ViewFrame.Detail, 2 },
        };

        public ContainerView()
        {
            
        }
        public override void DidReceiveMemoryWarning()
        {
            // Releases the view if it doesn't have a superview.
            base.DidReceiveMemoryWarning();

            // Release any cached data, images, etc that aren't in use.
        }
        
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            //Set up the bindings
            SetupBindings();
            SetupViews();

            // Perform any additional setup after loading the view

            View = new UniversalView();
            var label = new UILabel(new RectangleF(60, 100, 320, 20)) {Text = "Welcome to Onsight"};

            View.Add(label);

            AddChildViewController(Navigator);
            Navigator.View.Frame = this.View.Frame;
            View.AddSubview(Navigator.View);
            Navigator.DidMoveToParentViewController(this);

            ShowViewEvent = new ShowViewEvent(ViewType.CustomerEdit, ViewFrame.FullScreen, "");
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
            
            Mvx.LazyConstructAndRegisterSingleton(() => new CustomerDetailView{  });
            Mvx.LazyConstructAndRegisterSingleton(() => new CustomerEditView{  });
            Mvx.LazyConstructAndRegisterSingleton(() => new CustomerView {});
            Mvx.LazyConstructAndRegisterSingleton(() => new TabbedView { });
            Mvx.LazyConstructAndRegisterSingleton(() => new CustomerSplitView { });

            Views = new Dictionary<ViewType, IIosView>
            {
                {ViewType.CustomerDetails, Mvx.Resolve<CustomerDetailView>() },
                {ViewType.CustomerEdit, Mvx.Resolve<CustomerEditView>() },
                {ViewType.TabbedView, Mvx.Resolve<TabbedView>() },
                {ViewType.CustomerView, Mvx.Resolve<CustomerView>() },
            };
        }

        public void ShowView(ShowViewEvent showViewEvent)
        {
            //If the Views don't contain the showViewEvent viewType
            //Navigation is being handled by a child view and nothing more needs to be done
            if (!Views.ContainsKey(showViewEvent.ViewType)) return;

            var view = Views[showViewEvent.ViewType];
            var viewFrame = ViewFrames[showViewEvent.ViewFrame];
            var viewController = view.Controller as UIViewController;
            var viewTag = view.ViewTag;

            view.BaseViewModel.InitialiseCommand.Execute(showViewEvent);

            if (showViewEvent.ViewFrame == ViewFrame.Detail)
            {
                if((Views[ViewType.TabbedView] as TabbedView).UpdateDetail(viewController))
                    return;
            }

            if (viewController != null)
            {
                Navigator.NavigationController.PushViewController(viewController, true);
            }
            else
            {
                Debug.WriteLine("Unable to cast viewController as UIController:");
                Mvx.Trace(MvxTraceLevel.Error, "Unable to cast viewController as UIController: ");
            }

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