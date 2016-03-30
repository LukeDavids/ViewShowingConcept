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
        public ContainerViewModel() {
            RegisterViewModels();
        }

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

        private void RegisterViewModels() {
            Mvx.RegisterSingleton(new CustomerDetailViewModel());
            CustomerDetailViewModel = Mvx.Resolve<CustomerDetailViewModel>();

            Mvx.RegisterSingleton(new CustomerEditViewModel());
            CustomerEditViewModel = Mvx.Resolve<CustomerEditViewModel>();

            Mvx.RegisterSingleton(new CustomerListViewModel());
            CustomerListViewModel = Mvx.Resolve<CustomerListViewModel>();

            Mvx.RegisterSingleton(new LoginViewModel());
            LoginViewModel = Mvx.Resolve<LoginViewModel>();


        }
    }
}
