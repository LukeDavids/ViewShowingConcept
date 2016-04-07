using System;
using System.Drawing;

using CoreFoundation;
using UIKit;
using Foundation;
using ViewShowingConcept.Core.Enums;
using ViewShowingConcept.Core.ViewModels;

namespace ViewShowingConcept.Ios.Views
{
    [Register("UniversalView")]
    public class UniversalView : UIView
    {
        public UniversalView()
        {
            Initialize();
        }

        public UniversalView(RectangleF bounds) : base(bounds)
        {
            Initialize();
        }

        void Initialize()
        {
            BackgroundColor = UIColor.White;
        }
    }

    [Register("CustomerDetailView")]
    public class CustomerDetailView : Base.BaseView<CustomerDetailViewModel>
    {
        public CustomerDetailView()
        {
            ViewType = ViewType.CustomerDetails;
            ViewTag = ViewType.ToString();
        }

        public override void ShowViewModel()
        {
            CustomerDetailViewModel.ShowViewModel();
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

            // Perform any additional setup after loading the view
        }
    }
}