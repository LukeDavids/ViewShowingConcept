using System;
using System.Drawing;

using CoreFoundation;
using UIKit;
using Foundation;
using MvvmCross.Binding.BindingContext;
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

        public override void ShowViewModel()
        {
            ViewModel.ShowViewModel();
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
            var button = new UIButton(new RectangleF(10, 100, 140, 15));
            button.SetTitle("Show Tabs", UIControlState.Normal);
            button.SetTitleColor(UIColor.Black, UIControlState.Normal);
            var set = this.CreateBindingSet<CustomerDetailView, CustomerDetailViewModel>();
            View.Add(button);
            set.Bind(button).To(vm => vm.ShowTabbedCommand);
            set.Apply();
        }
    }
}