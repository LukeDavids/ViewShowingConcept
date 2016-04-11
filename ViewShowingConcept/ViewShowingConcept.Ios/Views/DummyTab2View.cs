using System;
using System.Drawing;

using CoreFoundation;
using UIKit;
using Foundation;
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

        public override void ViewDidLoad()
        {
            View = new UniversalView();

            base.ViewDidLoad();

            // Perform any additional setup after loading the view

            var label = new UILabel(new RectangleF(10, 60, 320, 40)) {Text = "Dummy Tab2"};
            View.Add(label);
        }
    }
}