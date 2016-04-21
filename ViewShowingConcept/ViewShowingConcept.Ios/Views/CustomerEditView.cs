
using System.Drawing;
using System.Resources;
using UIKit;
using Foundation;
using MvvmCross.Binding.BindingContext;
using ViewShowingConcept.Core.Enums;
using ViewShowingConcept.Core.ViewModels;
using ViewShowingConcept.Ios.Views.Base;
using ViewShowingConcept.Ios.Views.ViewTemplates;
using MapKit;
using CoreLocation;
using System;

namespace ViewShowingConcept.Ios.Views
{
    [Register("CustomerEditView")]
    public class CustomerEditView : BaseView<CustomerEditViewModel>
    {
        public CustomerEditView()
        {
            ViewType = ViewType.CustomerEdit;
            ViewTag = ViewType.ToString();
        }
			
        public override void ShowViewModel()
        {
            ViewModel.ShowViewModel();
        }

        public override void ViewDidLoad()
        {
            View = new Helper();

            base.ViewDidLoad();

            // Perform any additional setup after loading the view
            var button = new UIButton(new RectangleF(10,150,140,15));
            button.SetTitle("Show Detail", UIControlState.Normal);


			var set = this.CreateBindingSet<CustomerEditView, CustomerEditViewModel>();
			var label = new UILabel(new RectangleF(10, 50, 300, 40));
			var label2 = new UILabel (new RectangleF (10, 100, 300, 40));

			View.Add(label);
			View.Add(label2);
			View.Add(button);

            set.Bind(button).To(vm => vm.ShowDetailsCommand);

			set.Bind (label).To (vm => vm.Lat);
			set.Bind(label2).To(vm => vm.Lng);
            set.Apply();
        }
    }
}