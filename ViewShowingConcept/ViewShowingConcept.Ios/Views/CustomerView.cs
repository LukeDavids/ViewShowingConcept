using System;
using System.Drawing;

using CoreFoundation;
using UIKit;
using Foundation;
using MvvmCross.Binding.BindingContext;
using ViewShowingConcept.Core.ViewModels;
using ViewShowingConcept.Ios.Views.Base;

namespace ViewShowingConcept.Ios.Views
{
    [Register("CustomerView")]
    public class CustomerView : BaseView<CustomerViewModel>
    {
        public CustomerView()
        {
        }

        public override void DidReceiveMemoryWarning()
        {
            // Releases the view if it doesn't have a superview.
            base.DidReceiveMemoryWarning();

            // Release any cached data, images, etc that aren't in use.
        }
        public override void ShowViewModel()
        {
            ViewModel.ShowViewModel();
        }

        public override void ViewDidLoad()
        {
            View = new UniversalView();

            base.ViewDidLoad();

            var label = new UILabel(new RectangleF(10,50,150,50));
            var label2 = new UILabel(new RectangleF(10, 110, 150, 50));
            var label3 = new UILabel(new RectangleF(10, 170, 150, 50));

            var set = this.CreateBindingSet<CustomerView, CustomerViewModel>();
            set.Bind(label).To(vm => vm.CustomerName);
            set.Bind(label2).To(vm => vm.CustomerAge);
            set.Bind(label3).To(vm => vm.CustomerId);
            set.Apply();

            View.Add(label);
            View.Add(label2);
            View.Add(label3);

            // Perform any additional setup after loading the view
        }
    }
}