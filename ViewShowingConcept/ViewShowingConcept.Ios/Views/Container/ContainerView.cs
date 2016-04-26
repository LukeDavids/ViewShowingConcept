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
    public class ContainerView : MvxViewController<ContainerViewModel>, IUINavigationControllerDelegate, IIosNavigator
    {
        private readonly UIViewController _navigator = new UINavigationController();
        public Dictionary<ViewType, IIosView> Views { get; } = new Dictionary<ViewType, IIosView>();
        public ViewType CurrentSelected { get; set; }
        private Dictionary<ViewFrame, Delegate> _viewUpdateMethods { get; } = new Dictionary<ViewFrame, Delegate>();

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
            View = new UniversalView();

            base.ViewDidLoad();
            //Set up the bindings
            SetupBindings();
            SetupViews();
            
            // Perform any additional setup after loading the view
            
            var label = new UILabel(new RectangleF(60, 100, 320, 20)) {Text = "Welcome to Onsight"};

            View.Add(label);

            AddChildViewController(_navigator);
            _navigator.View.Frame = this.View.Frame;
            View.AddSubview(_navigator.View);
            _navigator.DidMoveToParentViewController(this);

            ShowViewEvent = new ShowViewEvent(ViewType.CustomerDetails, ViewFrame.FullScreen, "");
        }

        private ShowViewEvent _showViewEvent;
        public ShowViewEvent ShowViewEvent
        {
            get { return _showViewEvent; }
            set
            {
                _showViewEvent = value;
                UpdateView(_showViewEvent);
            }
        }

        public ViewDidShowEvent ViewDidShowEvent { get; set; }


        private void SetupViews()
        {
            Mvx.LazyConstructAndRegisterSingleton(() => new CustomerDetailView { });
            Mvx.LazyConstructAndRegisterSingleton(() => new CustomerEditView { });
            Mvx.LazyConstructAndRegisterSingleton(() => new TabbedView { });

            Views[ViewType.CustomerDetails] = Mvx.Resolve<CustomerDetailView>();
            Views[ViewType.CustomerEdit] = Mvx.Resolve<CustomerEditView>();
            Views[ViewType.TabbedView] = Mvx.Resolve<TabbedView>();

            _viewUpdateMethods[ViewFrame.Modal] = new Func<UIViewController, bool>(PresentController);
            _viewUpdateMethods[ViewFrame.FullScreen] = new Func<UIViewController, bool>(PushController);
            _viewUpdateMethods[ViewFrame.FullScreenTabs] = new Func<UIViewController, bool>(PushController);
            _viewUpdateMethods[ViewFrame.DismissModal] = new Func<UIViewController, bool>(DismissController);
        }

        public void UpdateView(ShowViewEvent showViewEvent)
        {
            //If the Views don't contain the showViewEvent viewType
            //Navigation is being handled by a child view and nothing more needs to be done
            if (Views.ContainsKey(showViewEvent.ViewType))
            {
                var view = Views[showViewEvent.ViewType];
                var viewController = view.Controller as UIViewController;
                var viewTag = view.ViewTag;

                view.BaseViewModel.InitialiseCommand.Execute(showViewEvent);

                CurrentSelected = showViewEvent.ViewType;

                _viewUpdateMethods[showViewEvent.ViewFrame].DynamicInvoke(viewController);
            }
            else
            {
                var view = Views[CurrentSelected];

                ((IIosNavigator) view).UpdateView(showViewEvent);
            }

        }

        private bool PushController(UIViewController vc)
        {
            _navigator.NavigationController.PushViewController(vc, true);
            return true;
        }

        private bool PresentController(UIViewController vc)
        {
            vc.ModalPresentationStyle = UIModalPresentationStyle.FormSheet;
            vc.ModalTransitionStyle = UIModalTransitionStyle.CoverVertical;

            _navigator.PresentViewController(vc, true, null);
            return true;
        }

        private bool DismissController(UIViewController vc)
        {
            _navigator.DismissViewController(true,null);
            return true;
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