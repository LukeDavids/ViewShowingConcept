using System;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;
using ViewShowingConcept.Core.Enums;
using ViewShowingConcept.Core.Models;
using ViewShowingConcept.Core.Services;
using ViewShowingConcept.Core.ViewModels.Base;

namespace ViewShowingConcept.Core.ViewModels
{
    public class CustomerViewModel : BaseViewModel
    {
        public CustomerViewModel()
        {
            StringPassedAsParameter = "nothing yet!";
        }

        private string _customerId;
        private string _customerName;
        private int _customerAge;

        private Customer Customer { get; set; }

        public string CustomerId
        {
            get { return _customerId; }
            set
            {
                _customerId = value;
                RaisePropertyChanged(() => CustomerId);
            }
        }

        public string CustomerName
        {
            get { return _customerName; }
            set
            {
                _customerName = value;
                RaisePropertyChanged(() => CustomerName);
            }
        }

        public int CustomerAge
        {
            get { return _customerAge; }
            set
            {
                _customerAge = value;
                RaisePropertyChanged(() => CustomerAge);
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
                if (CustomerService.GetCustomer(StringPassedAsParameter) != null)
                {
                    Customer = CustomerService.GetCustomer(StringPassedAsParameter);
                    CustomerId = Customer.Id;
                    CustomerName = Customer.CustomerName;
                    CustomerAge = Customer.CustomerAge;
                }
            }
        }

        public override async Task Initialise(ShowViewEvent viewEvent)
        {
            await Task.Run(() => StringPassedAsParameter = viewEvent.Parameter);
        }
    }
}