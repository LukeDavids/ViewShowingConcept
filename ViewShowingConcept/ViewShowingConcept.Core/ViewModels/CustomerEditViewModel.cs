using System;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;
using ViewShowingConcept.Core.Models;
using ViewShowingConcept.Core.ViewModels.Base;
using static ViewShowingConcept.Core.Enums.ViewType;
using static ViewShowingConcept.Core.Enums.ViewFrame;
using MvvmCross.Plugins.Messenger;
using MvvmCross.Plugins.Location;
using ViewShowingConcept.Core;

namespace ViewShowingConcept.Core.ViewModels
{
    public class CustomerEditViewModel : BaseViewModel
    {
		private string _stringParam;
		private readonly MvxSubscriptionToken _token;
		private double _lat;
		private double _lng;

		public CustomerEditViewModel()
		{

        }

		public CustomerEditViewModel(ILocationService service, IMvxMessenger messenger)
		{
			_token = messenger.Subscribe<LocationMessage> (OnLocationMessage);

		}

		private void OnLocationMessage(LocationMessage locationMessage)
		{
			Lat = locationMessage.Lat;
			Lng = locationMessage.Lng;
		}
			
		public double Lat
		{
			get { return _lat; }  
			set {
				_lat = value;
				RaisePropertyChanged(() => Lat);
			}
		}
			
		public double Lng
		{
			get { return _lng; }
			set {
				_lng = value;
				RaisePropertyChanged(() => Lng);
			}
		}
			
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
