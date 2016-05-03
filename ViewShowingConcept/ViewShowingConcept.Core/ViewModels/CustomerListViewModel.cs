using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;
using ViewShowingConcept.Core.Enums;
using ViewShowingConcept.Core.Interfaces;
using ViewShowingConcept.Core.Models;
using ViewShowingConcept.Core.Services;
using ViewShowingConcept.Core.ViewModels.Base;
using ViewShowingConcept.Core.ViewModels.Container;
using static ViewShowingConcept.Core.Enums.ViewType;
using static ViewShowingConcept.Core.Enums.ViewFrame;

namespace ViewShowingConcept.Core.ViewModels
{
    public class CustomerListViewModel : BaseViewModel 
    {
        public CustomerListViewModel() 
        {
        }
        
        public List<Customer> CustomerList => CustomerService.getCustomerList();

        private string _customerId;

        public string CustomerId
        {
            get { return _customerId; }
            set
            {
                _customerId = value;
                RaisePropertyChanged(() => CustomerId);
            }
        }

        private MvxCommand<Customer> _showCustomerCommand;
        public IMvxCommand ShowCustomerCommand
        {
            get
            {
                return
                    _showCustomerCommand =
                        _showCustomerCommand ??
                        new MvxCommand<Customer>(item => {
                            if (App.Tablet) // Take a look at DeviceUtilsService as well as the setup class's "setFormFactor" method in the Android project to check how this is set
                                ShowView(CustomerView, Detail, item.Id); 
                            else
                                ShowView(CustomerView, FullScreenTabs, item.Id);
                        });
            }
        }

        private string _stringParam;
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
    }
}
