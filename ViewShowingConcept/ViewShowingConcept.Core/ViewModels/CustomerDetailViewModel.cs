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
    public class CustomerDetailViewModel : BaseViewModel
    {
        private string _stringParam;

        public CustomerDetailViewModel()
		{
            StringPassedAsParameter = "nothing yet!";
        }
			
		private static CustomerDetailViewModel _instance = null;

        public string ButtonText => "Edit Customer";



		public static CustomerDetailViewModel Instance
		{
			get{
				return getInstance();
			}
		}
			
		public static CustomerDetailViewModel getInstance()
		{
			if (_instance == null)
				_instance = new CustomerDetailViewModel();

			return _instance;
		}


        public string StringPassedAsParameter
        {
            get { return _stringParam; }
            set
            {
                _stringParam = value;
                RaisePropertyChanged(() => StringPassedAsParameter);
            }
        }

        public ICommand ShowTabbedCommand
            => new MvxCommand(() => ShowView(TabbedView, FullScreen, DateTime.UtcNow.ToString()));

        public override async Task Initialise(ShowViewEvent viewEvent)
        {
            await Task.Run(() => StringPassedAsParameter = viewEvent.Parameter);
        }

        //Used to Init new ViewModel
        public void ShowViewModel()
        {
			ShowViewModel<CustomerDetailViewModel>(new {});
        }
    }
}
