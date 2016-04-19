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
		private static TabbedView _instance = null;
	
		public static TabbedView Instance
		{
			get{ return getInstance();}
		}

        public TabbedView()
        {
            ViewType = ViewType.TabbedView;
            ViewTag = ViewType.ToString();
        }

		private static TabbedView getInstance()
		{
			if(_instance == null)
				_instance = new TabbedView();

			return _instance;
		}

        public override void ShowViewModel()
        {
            ViewModel.ShowViewModel();
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

            _tabBar.SelectedViewController = _tabBar.ViewControllers[0];
            AddChildViewController(_tabBar);
            _tabBar.View.Frame = this.View.Frame;
            View.AddSubview(_tabBar.View);
            _tabBar.DidMoveToParentViewController(this);
        }

        private void SetTabs()
        {
            string[] images = new string[]
            {
                "glyphicons-social-44-apple","glyphicons-282-bullets","glyphicons-506-piggy-bank",
            };
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
    }
}