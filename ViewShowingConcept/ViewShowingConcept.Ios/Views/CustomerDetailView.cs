using System;
using System.Drawing;

using CoreFoundation;
using UIKit;
using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using ViewShowingConcept.Core.Enums;
using ViewShowingConcept.Core.ViewModels;
using ViewShowingConcept.Ios.Views.Base;

namespace ViewShowingConcept.Ios.Views
{
    [Register("CustomerDetailView")]
    public class CustomerDetailView : BaseView<CustomerDetailViewModel>
    {
        public CustomerDetailView()
        {
            ViewType = ViewType.CustomerDetails;
            ViewTag = ViewType.ToString();
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
            var button = new UIButton(new RectangleF(10, 100, 140, 20));
            button.SetTitle("Show Tabs", UIControlState.Normal);
            button.SetTitleColor(UIColor.Black, UIControlState.Normal);

            var editButton = new UIButton(new RectangleF(10, 130, 140, 20));
            editButton.SetTitle("Edit", UIControlState.Normal);
            editButton.SetTitleColor(UIColor.Black, UIControlState.Normal);

            View.Add(button);
            View.Add(editButton);

            var set = this.CreateBindingSet<CustomerDetailView, CustomerDetailViewModel>();
            set.Bind(button).To(vm => vm.ShowTabbedCommand);
            set.Bind(editButton).To(vm => vm.ShowEditCommand);
            set.Apply();
            
        }
    }
}