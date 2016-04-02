using MvvmCross.Core.ViewModels;
using System.Windows.Input;
using MvvmCross.Droid.Support.V7.Fragging.Fragments;
using ViewShowingConcept.Core.Interfaces;
using ViewShowingConcept.Core.Models;
using ViewShowingConcept.Core.Services;
using ViewShowingConcept.Core.ViewModels.Base;

namespace ViewShowingConcept.Core.ViewModels
{
    public class CustomerEditViewModel : BaseViewModel
    {
        public CustomerEditViewModel() { }

        private string _id;
        public string Id
        {
            get { return _id; }
            set
            {
                _id = value;
                RaisePropertyChanged(() => Id);
            }
        }

        private string _customerName;
        public string CustomerName
        {
            get { return _customerName; }
            set
            {
                _customerName = value;
                RaisePropertyChanged(() => CustomerName);
            }
        }

        private int _customerAge;
        private int CustomerAge
        {
            get { return _customerAge; }
            set
            {
                _customerAge = value;
                RaisePropertyChanged(() => CustomerAge);
            }
        }

        public ICommand UpdateCustomerCommand {
            get { return new MvxCommand(UpdateCustomer); }
        }

        private void UpdateCustomer() {
            foreach (Customer customer in CustomerServices.getCustomerList()) {
                if (Id.Equals(customer.getId())) {
                    customer.setCustomerAge(CustomerAge);
                    customer.setCustomerName(_customerName);
                }
            }
        }

        public bool IsMenuVisible { get; set; }
        public MvxFragment Fragment { get; set; }
    }
}
