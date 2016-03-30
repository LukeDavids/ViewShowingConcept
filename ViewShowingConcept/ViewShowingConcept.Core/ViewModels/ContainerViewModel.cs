using MvvmCross.Core.ViewModels;
using System.Windows.Input;
using ViewShowingConcept.Core.Enums;
using ViewShowingConcept.Core.Models;
using ViewShowingConcept.Core.Services;
using ViewShowingConcept.Core.ViewModels.Base;

namespace ViewShowingConcept.Core.ViewModels
{
    public class ContainerViewModel
        : BaseViewModel
    {
        public Customer Customer { get; set; }
        public LoginViewModel LoginViewModel { get; set; }
        public CustomerDetailViewModel CustomerDetailViewModel { get; set; }
        public CustomerEditViewModel CustomerEditViewModel { get; set; }
        public CustomerListViewModel CustomerListViewModel { get; set; }

        private string _customerId;
        public string CustomerId {
            get { return _customerId; }
            set {
                _customerId = value;
                RaisePropertyChanged(() => CustomerId);

                foreach (Customer tempCustomer in CustomerServices.getCustomerList()) {
                    if (tempCustomer.getId().Equals(value)) {
                        Customer = tempCustomer;
                    }
                }
            }
        }
    }
}
