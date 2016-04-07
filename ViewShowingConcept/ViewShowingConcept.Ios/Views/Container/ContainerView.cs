using System;
using System.Collections.Generic;
using System.Drawing;

using CoreFoundation;
using UIKit;
using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using MvvmCross.Platform;
using ViewShowingConcept.Core.Enums;
using ViewShowingConcept.Core.Models;
using ViewShowingConcept.Core.ViewModels;
using ViewShowingConcept.Core.ViewModels.Base;
using ViewShowingConcept.Core.ViewModels.Container;
using ViewShowingConcept.Ios.Interfaces;
using ViewShowingConcept.Ios.Views.Base;

namespace ViewShowingConcept.Ios.Views.Container
{
    [Register("ContainerView")]
    public class ContainerView : MvxViewController<ContainerViewModel>
    {
        public Dictionary<ViewType, IIosView> Views { get; set; }
        public Dictionary<ViewFrame, int> ViewFrames { get; set; } = new Dictionary<ViewFrame, int>()
        {
            {ViewFrame.FullScreen, 0 },
            {ViewFrame.TabContents, 1 }
        };

        public ContainerView()
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
            //Set up the bindings
            SetupBindings();
            SetupViews();
            ShowViewEvent = new ShowViewEvent(ViewType.CustomerEdit, ViewFrame.FullScreen, "none");

            // Perform any additional setup after loading the view

            View = new UniversalView();
            var label = new UILabel(new RectangleF(60, 100, 320, 20)) {Text = "Welcome to Onsight"};

            var button = new UIButton(new RectangleF(10, 200, 320, 40));
            button.SetTitle("Go to first view", UIControlState.Normal);
            button.TouchUpInside += delegate {
                ShowViewEvent = new ShowViewEvent(ViewType.CustomerEdit, ViewFrame.FullScreen, "none");
            };
            
            
            View.Add(label);
        }

        private ShowViewEvent _showViewEvent;
        public ShowViewEvent ShowViewEvent
        {
            get { return _showViewEvent; }
            set
            {
                _showViewEvent = value;
                ShowView(_showViewEvent);
            }
        }
        private void SetupViews()
        {
            
            Mvx.LazyConstructAndRegisterSingleton(() => new CustomerDetailView{  });
            Mvx.LazyConstructAndRegisterSingleton(() => new CustomerEditView{  });

            Views = new Dictionary<ViewType, IIosView>
            {
                {ViewType.CustomerDetails, Mvx.Resolve<CustomerDetailView>() },
                {ViewType.CustomerEdit, Mvx.Resolve<CustomerEditView>() }
            };
        }

        public void ShowView(ShowViewEvent showViewEvent)
        {           
            var view = Views[showViewEvent.ViewType];
            var viewFrame = ViewFrames[showViewEvent.ViewFrame];
            var viewController = view.Controller;
            var viewTag = view.ViewTag;

            //Add logic for transitioning between views in IOS
            try
            {
                view.BaseViewModel.InitialiseCommand.Execute(showViewEvent);
                view.ShowViewModel();
            }
            catch (SystemException e)
            {
                Console.WriteLine("LOOK HERE"+e.Message);
            }
        }
        private void SetupBindings()
        {
            this.CreateBinding(this)
                .For(view => view.ShowViewEvent)
                .To<ContainerViewModel>(vm => vm.ShowViewEvent)
                .Apply();

        }
    }
}