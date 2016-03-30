using ViewShowingConcept.Core.Models;
using System.Collections.Generic;
using ViewShowingConcept.Core.ViewModels.Base;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;
using ViewShowingConcept.Core.Enums;

namespace ViewShowingConcept.Core.ViewModels
{
    public class CustomerListViewModel
        : BaseViewModel
    {
        public CustomerListViewModel() { }

        private List<Customer> _customers;
        public List<Customer> Customers {
            get { return _customers; }
            set {
                _customers = value;
                RaisePropertyChanged(() => Customers);
            }
        }

        public ICommand ShowCustomerDetailViewCommand {
            get {
                return new MvxCommand(ShowCustomerDetailView);
            }
        }

        private void ShowCustomerDetailView() {
            ShowSubView(SubView.CustomerDetails);
        }
    }
}
