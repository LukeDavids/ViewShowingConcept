using System;
using System.Diagnostics;
using System.Drawing;

using CoreFoundation;
using UIKit;
using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using MvvmCross.iOS.Views;
using MvvmCross.Platform;
using ViewShowingConcept.Core.Enums;
using ViewShowingConcept.Core.ViewModels;
using ViewShowingConcept.Ios.Interfaces;
using ViewShowingConcept.Ios.Views.Base;
using ViewShowingConcept.Ios.Views.ViewTemplates;
using MvvmCross.Core.Views;

namespace ViewShowingConcept.Ios.Views
{
    [Register("CustomerListView")]
    public class CustomerListView : BaseView<CustomerListViewModel>
    {
        
        public CustomerListView()
        {
            ViewType = ViewType.CustomerList;
            ViewTag = ViewType.ToString();
        }

        public CustomerListView(IntPtr handle) : base(handle)
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
            View = new UniversalView();

            base.ViewDidLoad();

            // Perform any additional setup after loading the view

            var label = new UILabel(new RectangleF(10, 50, 150, 60));
            View.Add(label);

            var tableView = new UITableView(new RectangleF(10, 120, 300, 400), UITableViewStyle.Plain);

            var source = new MvxStandardTableViewSource(tableView, "TitleText CustomerName");

            var set = this.CreateBindingSet<CustomerListView, CustomerListViewModel>();
            set.Bind(source).To(vm => vm.CustomerList);
            set.Bind(source).For(s => s.SelectionChangedCommand).To(vm => vm.ShowCustomerCommand);
            set.Bind(label).To(vm => vm.CustomerList.Count);
            set.Apply();

            tableView.Source = source;

            View.Add(tableView);

            tableView.ReloadData();
        }

    }

}