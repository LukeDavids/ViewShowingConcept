using System;
using System.Drawing;

using CoreGraphics;
using Foundation;
using UIKit;

namespace ViewShowingConcept.Ios.Views.ViewTemplates
{
    [Register("Helper")]
    public class Helper : UIView
    {
        public Helper()
        {
            Initialize();
        }

        public Helper(RectangleF bounds) : base(bounds)
        {
            Initialize();
        }

        void Initialize()
        {
            BackgroundColor = UIColor.Red;
        }
    }
}