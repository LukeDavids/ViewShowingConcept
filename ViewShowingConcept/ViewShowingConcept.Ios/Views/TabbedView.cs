using System;
using System.Drawing;

using CoreFoundation;
using UIKit;
using Foundation;
using MvvmCross.Core.ViewModels;
using MvvmCross.Core.Views;
using MvvmCross.iOS.Views;
using MvvmCross.Platform;
using MvvmCross.Platform.Core;
using ViewShowingConcept.Core.ViewModels;
using ViewShowingConcept.Ios.Views.Base;

namespace ViewShowingConcept.Ios.Views
{
    [Register("TabbedView")]
    public class TabbedView : BaseTabbedView<TabbedViewModel>
    {
        private int _createdSoFar = 0;
        public TabbedView()
        {
            ViewDidLoad();
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
            if (ViewModel == null) return;

            // Perform any additional setup after loading the view
            ViewControllers = new UIViewController[]
            {
                CreateTabFor("Tab1", "glyphicons-social-44-apple", Mvx.Resolve<DummyTab1ViewModel>()),
                CreateTabFor("Tab2", "glyphicons-282-bullets", Mvx.Resolve<DummyTab2ViewModel>()),
                CreateTabFor("Tab3", "glyphicons-506-piggy-bank", Mvx.Resolve<DummyTab3ViewModel>())
            };
            CustomizableViewControllers = null;
            SelectedViewController = ViewControllers[0];
        }
        private UIViewController CreateTabFor(string title, string imageName, IMvxViewModel viewModel)
        {
            var controller = new UINavigationController();
            var screen = this.CreateViewControllerFor(viewModel) as UIViewController;
            SetTitleAndTabBarItem(title, imageName, screen);
            controller.PushViewController(screen, false);
            return controller;
        }
        private UIViewController CreateTabFor(string title, string imageName, UIViewController view)
        {
            var controller = new UINavigationController();
            SetTitleAndTabBarItem(title, imageName, view);
            controller.PushViewController(view, false);
            return controller;
        }

        private void SetTitleAndTabBarItem(string title, string imageName, UIViewController screen)
        {
            screen.Title = title;
            var image = UIImage.FromBundle("Images/Tabs/" + imageName + ".png");
            screen.TabBarItem = new UITabBarItem(title, image, _createdSoFar);
            _createdSoFar++;
        }
    }
}