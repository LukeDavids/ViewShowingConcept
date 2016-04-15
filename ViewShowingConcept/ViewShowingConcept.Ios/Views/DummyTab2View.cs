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
        public DummyTab2View(IntPtr handle) : base(handle)
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
            //Instantiate views here
            var label = new UILabel()
            {
                Text = "Dummy Tab2"
            };
            var edittext = new UITextField()
            {
                BorderStyle = UITextBorderStyle.Line
            };
            var colorbutton = new UIButton();
            var num = new UILabel();
            var numbutton = new UIButton();
            var label2 = new UILabel();
            var button = new UIButton();

            //Set up bindings here
            var set = this.CreateBindingSet<DummyTab2View, DummyTab2ViewModel>();
            set.Bind(label).To(vm => vm.Label1);
            set.Bind(edittext).To(vm => vm.Label1);
            set.Bind(num).To(vm => vm.Num1);
            set.Bind(label2).To(vm => vm.Label2);
            set.Apply();
            
            //Set constraints here
            //num.LeadingAnchor.ConstraintEqualTo(View.LeadingAnchor);

            //Add views here
            View.Add(label);
            View.Add(edittext);
            View.Add(num);
        }
    }
}