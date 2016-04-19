
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
			
		private static CustomerEditView _instance = null;

		public static CustomerEditView Instance
		{
			get { return getInstance (); }
		}
			
		private static CustomerEditView getInstance()
		{
			if (_instance == null)
				_instance = new CustomerEditView();

			return _instance;
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
            var button = new UIButton(new RectangleF(10,100,140,15));
            button.SetTitle("Show Detail", UIControlState.Normal);
            var set = this.CreateBindingSet<CustomerEditView, CustomerEditViewModel>();
            View.Add(button);
            set.Bind(button).To(vm => vm.ShowDetailsCommand);
            set.Apply();
        }
    }
}