using System;
using System.Drawing;

using CoreFoundation;
using UIKit;
using Foundation;
using MvvmCross.Core.ViewModels;
using MvvmCross.iOS.Views;
using ViewShowingConcept.Core.ViewModels;
using ViewShowingConcept.Ios.Views.Base;

namespace ViewShowingConcept.Ios.Views
{
    [Register("CustomerSplitView")]
    public class CustomerSplitView : BaseView<CustomerSplitViewModel>, IUISplitViewControllerDelegate
    {
        private UISplitViewController _splitView;
        public CustomerSplitView()
        {
        }

        public CustomerSplitView(IntPtr handle) : base(handle)
        {
        }

        public override void DidReceiveMemoryWarning()
        {
            // Releases the view if it doesn't have a superview.
            base.DidReceiveMemoryWarning();

            // Release any cached data, images, etc that aren't in use.
        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
            ViewModel.AlertViewModel();
        }

        public override void ViewDidLoad()
        {
            View = new UniversalView();

            base.ViewDidLoad();

            // Perform any additional setup after loading the view
            _splitView = new UISplitViewController();
            _splitView.ViewControllers = new UIViewController[]
            {
                this.CreateViewControllerFor(ViewModel.Master) as UIViewController,
                this.CreateViewControllerFor(ViewModel.Detail) as UIViewController,
            };
            _splitView.Delegate = this;
            
            //This needs to be sent to the container or rootviewcontroller
            NavigationItem.LeftBarButtonItem = _splitView.DisplayModeButtonItem;
            NavigationItem.LeftItemsSupplementBackButton = true;
            AddChildViewController(_splitView);
            _splitView.View.Frame = this.View.Frame;
            View.AddSubview(_splitView.View);
            _splitView.DidMoveToParentViewController(this);
        }

        public bool UpdateDetail(UIViewController vc)
        {
            if (_splitView.Collapsed)
            {
                return false;
            }
            _splitView.ShowDetailViewController(vc, null);
            return true;
        }
    }
}