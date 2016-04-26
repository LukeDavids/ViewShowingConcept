using System;
using System.Collections.Generic;
using UIKit;
using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using MvvmCross.Platform;
using ViewShowingConcept.Core.Enums;
using ViewShowingConcept.Core.Interfaces;
using ViewShowingConcept.Core.Models;
using ViewShowingConcept.Core.ViewModels;
using ViewShowingConcept.Core.ViewModels.Container;
using ViewShowingConcept.Ios.Interfaces;
using ViewShowingConcept.Ios.Views.Base;

namespace ViewShowingConcept.Ios.Views
{
    [Register("TabbedView")]
    public class TabbedView : BaseView<TabbedViewModel>, IUITabBarControllerDelegate, IIosNavigator
    {
        public Dictionary<ViewType, IIosView> Views { get; set; } = new Dictionary<ViewType, IIosView>();
        public ViewType CurrentSelected { get; set; }
        private int _createdSoFar = 0;
        private UITabBarController _tabBar;
        public int NumTabs { get; }

        public TabbedView()
        {
            ViewType = ViewType.TabbedView;
            ViewTag = ViewType.ToString();
        }

        public void UpdateView(ShowViewEvent showViewEvent)
        {
            if (Views.ContainsKey(showViewEvent.ViewType))
            {
                CurrentSelected = showViewEvent.ViewType;
                var view = Views[showViewEvent.ViewType];
                view.BaseViewModel.InitialiseCommand.Execute(showViewEvent);
            }
            else
            {
                ((IIosNavigator)Views[CurrentSelected]).UpdateView(showViewEvent);
            }
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

            SetupBindings();

            // Perform any additional setup after loading the view
            
            _tabBar = new UITabBarController();
            _tabBar.Delegate = this;
            SetTabs();
            //AddGestureRecognition();

            _tabBar.SelectedViewController = _tabBar.ViewControllers[0];
            AddChildViewController(_tabBar);
            _tabBar.View.Frame = this.View.Frame;
            View.AddSubview(_tabBar.View);
            _tabBar.DidMoveToParentViewController(this);
            
        }

        private void SetTabs()
        {
            string[] images = ViewModel.TabImages;
            //Please be true
            var x = ViewModel.NumTabs == NumTabs;
            UIViewController[] controllers = new UIViewController[ViewModel.NumTabs];
            for (var i = 0; i < ViewModel.NumTabs; i++)
            {
                ITab tab = ViewModel.Tabs[i];
                Views[tab.ViewType] = this.CreateViewControllerFor(tab.Page) as IIosView;
                tab.Image = i < images.Length ? images[i] : "";
                controllers[i] = CreateTabFor(tab);
            }
            _tabBar.ViewControllers = controllers;

            
        }
        private UIViewController CreateTabFor(ITab tab)
        {
            var screen = Views[tab.ViewType].Controller as UIViewController;
            SetTitleAndTabBarItem(tab.Name, tab.Image, screen);
            return screen;
        }

        private void SetTitleAndTabBarItem(string title, string imageName, UIViewController screen)
        {
            screen.Title = title;
            var image = UIImage.FromBundle("Images/Tabs/" + imageName + ".png");
            screen.TabBarItem = new UITabBarItem(title, image, _createdSoFar);
            ((IIosView)screen).ChildNum = _createdSoFar;
            _createdSoFar++;
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
        private void LeftToRight()
        {
            nint index = _tabBar.SelectedIndex;
            if (index > 0)
                _tabBar.SelectedIndex = index - 1;
            _tabBar.SelectedViewController = _tabBar.ViewControllers[_tabBar.SelectedIndex];
        }

        private void RightToLeft()
        {
            nint index = _tabBar.SelectedIndex;
            if (index < _tabBar.TabBar.Items.Length - 1)
                _tabBar.SelectedIndex = index + 1;
            _tabBar.SelectedViewController = _tabBar.ViewControllers[_tabBar.SelectedIndex];
        }

        private void SetupBindings()
        {
            var set = this.CreateBindingSet<TabbedView, TabbedViewModel>();
            set.Bind(this).For(v => v.NumTabs).To(vm => vm.NumTabs);
            set.Apply();
        }
    }
}