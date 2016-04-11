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
    [Register("DummyTab3View")]
    public class DummyTab3View : BaseView<DummyTab3ViewModel>
    {
        public DummyTab3View()
        {
            ViewType = ViewType.DummyTab3View;
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

            var label = new UILabel(new RectangleF(10, 60, 320, 40)) { Text = "Dummy Tab3" };
            View.Add(label);
        }
    }
}