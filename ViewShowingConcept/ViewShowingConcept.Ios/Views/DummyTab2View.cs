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
    [Register("DummyTab2View")]
    public class DummyTab2View : BaseView<DummyTab2ViewModel>
    {
        public DummyTab2View()
        {
            ViewType = ViewType.DummyTab2View;
            ViewTag = ViewType.ToString();
            
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

            var label = new UILabel(new RectangleF(10, 60, 320, 40)) {Text = "Dummy Tab2"};
            var edittext = new UITextField(new RectangleF(10, 110, 320, 40));
            var num = new UILabel(new RectangleF(10, 160, 320, 40));
            var set = this.CreateBindingSet<DummyTab2View, DummyTab2ViewModel>();
            set.Bind(edittext).To(vm => vm.Number);
            set.Bind(num).To(vm => vm.Number);
            set.Apply();
            View.Add(label);
            View.Add(edittext);
            View.Add(num);
        }
    }
}