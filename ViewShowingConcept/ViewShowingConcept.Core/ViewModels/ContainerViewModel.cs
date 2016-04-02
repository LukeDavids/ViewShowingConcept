using MvvmCross.Core.ViewModels;
using System.Windows.Input;
using MvvmCross.Platform;
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
