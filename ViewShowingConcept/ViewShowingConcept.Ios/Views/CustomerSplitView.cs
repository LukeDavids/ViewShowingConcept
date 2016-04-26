using System;
using System.Collections.Generic;
using System.Drawing;

using CoreFoundation;
using UIKit;
using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Core.ViewModels;
using MvvmCross.iOS.Views;
using MvvmCross.Platform;
using ViewShowingConcept.Core.Enums;
using ViewShowingConcept.Core.Models;
using ViewShowingConcept.Core.ViewModels;
using ViewShowingConcept.Ios.Interfaces;
using ViewShowingConcept.Ios.Views.Base;

namespace ViewShowingConcept.Ios.Views
{
    [Register("CustomerSplitView")]
    public class CustomerSplitView : BaseView<CustomerSplitViewModel>, IUISplitViewControllerDelegate, IIosNavigator
    {
        private IMvxViewModel _masterViewModel;
        private IMvxIosView _master;
        public IMvxIosView Master
        {
            //The set accessor is not meant to use the value parameter as this will break the link to the ViewModel
            get { return _master;}
            set { _master = this.CreateViewControllerFor(_masterViewModel); }
        }
        private IMvxViewModel Detail;
        public Dictionary<ViewType, IIosView> Views { get; set; } = new Dictionary<ViewType, IIosView>();
        private Dictionary<ViewType, Delegate> _viewUpdateMethods { get; } = new Dictionary<ViewType, Delegate>();
        public ViewType CurrentSelected { get; set; }
        private UISplitViewController _splitView;
        public CustomerSplitView()
        {
            
        }

        public CustomerSplitView(IntPtr handle) : base(handle)
        {

        }

        public void UpdateView(ShowViewEvent showViewEvent)
        {
            if (Views.ContainsKey(showViewEvent.ViewType))
            {
                CurrentSelected = showViewEvent.ViewType;
                var view = Views[showViewEvent.ViewType];

                view.BaseViewModel.InitialiseCommand.Execute(showViewEvent);

                var viewController = view as UIViewController;
                _viewUpdateMethods[showViewEvent.ViewType].DynamicInvoke(viewController);
            }
            else
            {
                
            }
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

            _viewUpdateMethods[ViewType.CustomerView] = new Func<UIViewController, bool>(UpdateDetail);
            _viewUpdateMethods[ViewType.CustomerList] = new Func<UIViewController, bool>( vc => true );

            Mvx.LazyConstructAndRegisterSingleton(() => new CustomerListView());
            Mvx.LazyConstructAndRegisterSingleton(() => new CustomerView());

            Views[ViewType.CustomerList] = Mvx.Resolve<CustomerListView>();
            Views[ViewType.CustomerView] = Mvx.Resolve<CustomerView>();

            // Perform any additional setup after loading the view
            _splitView = new UISplitViewController();
            _splitView.ViewControllers = new UIViewController[]
            {
                (UIViewController) Views[ViewType.CustomerList],
                (UIViewController) Views[ViewType.CustomerView],
                //this.CreateViewControllerFor(ViewModel.Master) as UIViewController,
                //this.CreateViewControllerFor(ViewModel.Detail) as UIViewController,
            };

            
            _splitView.Delegate = this;

            AddChildViewController(_splitView);
            _splitView.View.Frame = this.View.Frame;
            View.AddSubview(_splitView.View);
            _splitView.DidMoveToParentViewController(this);
        }

        public bool UpdateDetail(UIViewController vc)
        {
            if (_splitView.Collapsed)
            {
                NavigationController.PushViewController(vc,true);
                return true;
            }
            _splitView.ShowDetailViewController(vc, null);
            return true;
        }

        private void createBindings()
        {
            var set = this.CreateBindingSet<CustomerSplitView, CustomerSplitViewModel>();
            set.Bind(_masterViewModel).To(vm => vm.Master);
        }
    }
}