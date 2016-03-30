using MvvmCross.Core.ViewModels;
using System.Windows.Input;
using ViewShowingConcept.Core.Enums;
using ViewShowingConcept.Core.ViewModels.Base;

namespace ViewShowingConcept.Core.ViewModels
{
    public class CustomerDetailViewModel 
        : BaseViewModel
    {
        public CustomerDetailViewModel() { }

        private string _id;
        public string Id {
            get { return _id; }
            set {
                _id = value;
                RaisePropertyChanged(() => Id);
            }
        }

        private string _customerName;
        public string CustomerName {
            get { return _customerName; }
            set {
                _customerName = value;
                RaisePropertyChanged(() => CustomerName);
            }
        }

        private int _customerAge;
        private int CustomerAge {
            get { return _customerAge; }
            set {
                _customerAge = value;
                RaisePropertyChanged(() => CustomerAge);
            }
        }

        public ICommand ShowCustomerEditViewCommand {
            get { return new MvxCommand(ShowCustomerEditView); }
        }

        private void ShowCustomerEditView() {
            ShowSubView(SubView.CustomerEdit);
        }
    }
}
