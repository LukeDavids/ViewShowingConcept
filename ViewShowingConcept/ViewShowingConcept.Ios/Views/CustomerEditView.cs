
using System.Drawing;
using System.Resources;
using UIKit;
using Foundation;
using MvvmCross.Binding.BindingContext;
using ViewShowingConcept.Core.Enums;
using ViewShowingConcept.Core.ViewModels;
using ViewShowingConcept.Ios.Views.Base;
using ViewShowingConcept.Ios.Views.ViewTemplates;

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
            CustomerEditViewModel.ShowViewModel();
        }

        public override void ViewDidLoad()
        {
            View = new Helper();

            base.ViewDidLoad();

            // Perform any additional setup after loading the view
            var button = new UIButton(new RectangleF(10,100,140,15));
            button.SetTitle("Show Detail", UIControlState.Normal);
            var set = this.CreateBindingSet<CustomerEditView, CustomerEditViewModel>();
            View.Add(button);
            set.Bind(button).To(vm => vm.ShowDetailsCommand);
            set.Apply();
        }
    }
}