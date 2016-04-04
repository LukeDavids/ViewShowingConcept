using System;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
using System.Windows.Input;
using MvvmCross.Droid.Support.V7.Fragging.Fragments;
using ViewShowingConcept.Core.Enums;
using ViewShowingConcept.Core.Interfaces;
using ViewShowingConcept.Core.Models;
using ViewShowingConcept.Core.Services;
using ViewShowingConcept.Core.ViewModels.Base;
using static ViewShowingConcept.Core.Enums.ViewType;
using static ViewShowingConcept.Core.Enums.ViewFrame;

namespace ViewShowingConcept.Core.ViewModels
{
    public class CustomerEditViewModel : BaseViewModel
    {


        public CustomerEditViewModel()
        {
            StringPassedAsParameter = "nothing yet!";
        }

        private string _stringParam;

        public string ButtonText => "Customer Details!!";
        public ICommand ShowDetailsCommand => new MvxCommand(()=> ShowView(CustomerDetails, FullScreen, DateTime.UtcNow.ToString()));
        public string StringPassedAsParameter { get { return _stringParam; } set { _stringParam = value; RaisePropertyChanged(() => StringPassedAsParameter); } }

        public override async Task Initialise(ShowViewEvent viewEvent)
        {
            await Task.Run(() => StringPassedAsParameter = viewEvent.Parameter);
        }
    }
}
