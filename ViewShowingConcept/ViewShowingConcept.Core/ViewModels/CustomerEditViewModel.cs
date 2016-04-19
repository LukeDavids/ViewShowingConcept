using System;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;
using ViewShowingConcept.Core.Models;
using ViewShowingConcept.Core.ViewModels.Base;
using static ViewShowingConcept.Core.Enums.ViewType;
using static ViewShowingConcept.Core.Enums.ViewFrame;

namespace ViewShowingConcept.Core.ViewModels
{
    public class CustomerEditViewModel : BaseViewModel
    {
        public CustomerEditViewModel()
		{
            StringPassedAsParameter = "nothing yet!";
        }

        private string _stringParam;

		private static CustomerEditViewModel _instance = null;	

        public string ButtonText => "Customer Details!!";

        public ICommand ShowDetailsCommand
            => new MvxCommand(() => ShowView(CustomerDetails, FullScreen, DateTime.UtcNow.ToString()));

        public string StringPassedAsParameter
        {
            get { return _stringParam; }
            set
            {
                _stringParam = value;
                RaisePropertyChanged(() => StringPassedAsParameter);
            }
        }
			
		public static CustomerEditViewModel Instance
		{
			get { return getInstance();}
		}
			
		private static CustomerEditViewModel getInstance()
		{
			if (_instance == null) 
				_instance = new CustomerEditViewModel ();

			return _instance;
		}

        public override async Task Initialise(ShowViewEvent viewEvent)
        {
            await Task.Run(() => StringPassedAsParameter = viewEvent.Parameter);
        }

        //Used to Init new ViewModel
        public void ShowViewModel()
        {
            ShowViewModel<CustomerEditViewModel>(new {});
        }
    }
}
