using System;
using UIKit;
using Foundation;
using MvvmCross.iOS.Views;
using ViewShowingConcept.Core.Enums;
using ViewShowingConcept.Core.Interfaces;
using ViewShowingConcept.Core.ViewModels;
using ViewShowingConcept.Ios.Views.Base;

namespace ViewShowingConcept.Ios.Views
{
    [Register("TabbedView")]
    public class TabbedView : BaseView<TabbedViewModel>
    {
        private int _createdSoFar = 0;
        private UITabBarController _tabBar;
        public TabbedView()
        {
            ViewType = ViewType.TabbedView;
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
            
            _tabBar = new UITabBarController();
            SetTabs();
            //AddGestureRecognition();

            _tabBar.SelectedViewController = _tabBar.ViewControllers[0];
            AddChildViewController(_tabBar);
            _tabBar.View.Frame = this.View.Frame;
            View.AddSubview(_tabBar.View);
            _tabBar.DidMoveToParentViewController(this);
            
        }

        private void AddGestureRecognition()
        {
            Action lAction = (LeftToRight);
            UISwipeGestureRecognizer leftToRight = new UISwipeGestureRecognizer(lAction);
            leftToRight.Direction = UISwipeGestureRecognizerDirection.Right;
            _tabBar.TabBar.AddGestureRecognizer(leftToRight);

            Action rAction = (RightToLeft);
            UISwipeGestureRecognizer rightToLeft = new UISwipeGestureRecognizer(rAction);
            rightToLeft.Direction = UISwipeGestureRecognizerDirection.Left;
            _tabBar.TabBar.AddGestureRecognizer(rightToLeft);
        }

        private void SetTabs()
        {
            string[] images = ViewModel.TabImages;
            
            UIViewController[] controllers = new UIViewController[ViewModel.NumTabs];
            for (var i = 0; i < ViewModel.NumTabs; i++)
            {
                ITab tab = ViewModel.Tabs[i];
                tab.Image = i< images.Length ? images[i] : "";
                controllers[i] = CreateTabFor(tab);
            }
            _tabBar.ViewControllers = controllers;
        }
        private UIViewController CreateTabFor(ITab tab)
        {
            var controller = new UINavigationController();
            var screen = this.CreateViewControllerFor(tab.Page) as UIViewController;
            SetTitleAndTabBarItem(tab.Name, tab.Image, screen);
            controller.PushViewController(screen, false);
            return controller;
        }

        private void SetTitleAndTabBarItem(string title, string imageName, UIViewController screen)
        {
            screen.Title = title;
            var image = UIImage.FromBundle("Images/Tabs/" + imageName + ".png");
            screen.TabBarItem = new UITabBarItem(title, image, _createdSoFar);
            _createdSoFar++;
        }
        private void LeftToRight()
        {
            nint index = _tabBar.SelectedIndex;
            if (index > 0)
                _tabBar.SelectedIndex = index - 1;
        }

        private void RightToLeft()
        {
            nint index = _tabBar.SelectedIndex;
            if (index < _tabBar.TabBar.Items.Length - 1)
                _tabBar.SelectedIndex = index + 1;
        }
    }
}