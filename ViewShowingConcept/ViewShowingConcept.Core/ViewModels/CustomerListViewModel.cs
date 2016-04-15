﻿using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;
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
            CustomerList = CustomerService.getCustomerList();
        }

        public List<Customer> CustomerList { get; set; }
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

        public ICommand ShowCustomerCommand
        {
            get
            {
                return
                    _showCustomerCommand =
                        _showCustomerCommand ??
                        new MvxCommand<Customer>(item => { ShowView(CustomerView, HalfScreenBottom, item.Id); });
            }
        }

        public ContainerViewModel ContainerViewModel2 { get; set; }
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
