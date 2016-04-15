using System;
using System.Drawing;
using Cirrious.FluentLayouts.Touch;
using UIKit;
using Foundation;
using MvvmCross.Binding.BindingContext;
using ViewShowingConcept.Core.Enums;
using ViewShowingConcept.Core.ViewModels;
using ViewShowingConcept.Ios.Views.Base;

namespace ViewShowingConcept.Ios.Views
{
    [Register("DummyTab1View")]
    public class DummyTab1View : BaseView<DummyTab1ViewModel>
    {
        public DummyTab1View()
        {
            ViewType = ViewType.DummyTab1View;
            ViewTag = ViewType.ToString();
        }

        public DummyTab1View(IntPtr handle) : base(handle)
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
            //Instantiate sub views
            var label = new UILabel()
            {
                Text = "Dummy Tab1",
                TextColor = UIColor.Black                
            };
            var edittext = new UITextField()
            {
                BorderStyle = UITextBorderStyle.Line,
            };
            var num = new UILabel();
            var set = this.CreateBindingSet<DummyTab1View, DummyTab1ViewModel>();

            //Add Views
            View.Add(label);
            View.Add(edittext);
            View.Add(num);

            //Add constraints
            View.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();
            var padding = DeviceIsIPhone() ? 10f : 20f;
            var basicwidth = (UIScreen.MainScreen.Bounds.Width - 2 * padding);
            var basicheight = (UIScreen.MainScreen.Bounds.Height - 2 * padding)/6;
            View.AddConstraints(
                label.WithSameCenterX(View),
                label.WithSameCenterY(View).Minus(20f),
                label.WithRelativeWidth(View, 0.5f),
                label.WithRelativeHeight(View, 0.10f),

                edittext.Below(label),
                edittext.WithSameCenterX(View),
                edittext.WithRelativeWidth(View, 0.5f),
                edittext.WithRelativeHeight(View, 0.10f),

                num.Below(edittext),
                num.WithSameCenterX(View),
                num.WithRelativeWidth(View, 0.5f),
                num.WithRelativeHeight(View, 0.10f)
            );
            

            //Set up Bindings
            set.Bind(edittext).To(vm => vm.Number);
            set.Bind(num).To(vm => vm.Number);
            set.Apply();

            
            
        }
    }
}