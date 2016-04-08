using System;
using System.Drawing;

using CoreFoundation;
using UIKit;
using Foundation;
using MvvmCross.iOS.Views;
using MvvmCross.Platform;
using ViewShowingConcept.Core.Enums;
using ViewShowingConcept.Core.ViewModels.Base;
using ViewShowingConcept.Ios.Interfaces;

namespace ViewShowingConcept.Ios.Views.Base
{
    [Register("BaseTabbedView")]
    public class BaseTabbedView<TViewModel> : MvxTabBarViewController<TViewModel>, IIosView where TViewModel : BaseTabbedViewModel, new()
    {
        public BaseViewModel BaseViewModel { get; } = Mvx.Resolve<BaseTabbedViewModel>();
        public IMvxIosView Controller => this;
        public ViewType ViewType { get; set; }
        public string ViewTag { get; set; }

        public virtual void ShowViewModel()
        {
            throw new NotImplementedException();
        }

        public BaseTabbedView()
        {
        }

        public override void DidReceiveMemoryWarning()
        {
            // Releases the view if it doesn't have a superview.
            base.DidReceiveMemoryWarning();

            // Release any cached data, images, etc that aren't in use.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // Perform any additional setup after loading the view
        }
    }
}