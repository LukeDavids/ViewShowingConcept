using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;
using ViewShowingConcept.Core.Models;
using ViewShowingConcept.Core.Services;
using ViewShowingConcept.Core.ViewModels.Base;
using static ViewShowingConcept.Core.Enums.ViewType;
using static ViewShowingConcept.Core.Enums.ViewFrame;

namespace ViewShowingConcept.Core.ViewModels
{
    public class CustomerDetailViewModel : BaseViewModel
    {
        private string _stringParam;

        public List<Customer> CustomerList => CustomerService.getCustomerList();

        public CustomerDetailViewModel()
        {
            StringPassedAsParameter = "nothing yet!";
        }

        public string ButtonText => "Edit Customer";

        public string StringPassedAsParameter
        {
            get { return _stringParam; }
            set
            {
                _stringParam = value;
                RaisePropertyChanged(() => StringPassedAsParameter);
            }
        }

        public IMvxCommand ShowTabbedCommand
            => new MvxCommand(() => ShowView(TabbedView, FullScreen, DateTime.UtcNow.ToString()));

        public IMvxCommand ShowEditCommand
            => new MvxCommand(() => ShowView(CustomerEdit, Modal, DateTime.UtcNow.ToString()));

        public override async Task Initialise(ShowViewEvent viewEvent)
        {
            await Task.Run(() => StringPassedAsParameter = viewEvent.Parameter);
        }
    }
}
