using MvvmCross.Core.ViewModels;
using System.Windows.Input;
using MvvmCross.Droid.Support.V7.Fragging.Fragments;
using ViewShowingConcept.Core.Enums;
using ViewShowingConcept.Core.Interfaces;
using ViewShowingConcept.Core.ViewModels.Base;

namespace ViewShowingConcept.Core.ViewModels
{
    public class CustomerDetailViewModel 
        : BaseViewModel, ISubView
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

        public bool IsMenuVisible { get; set; }
        public MvxFragment Fragment { get; set; }
    }
}
