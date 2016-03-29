using MvvmCross.Core.ViewModels;
using System.Windows.Input;
using ViewShowingConcept.Core.Enums;
using ViewShowingConcept.Core.ViewModels.Base;

namespace ViewShowingConcept.Core.ViewModels
{
    public class ContainerViewModel
        : BaseViewModel
    {
        public LoginViewModel LoginViewModel { get; set; }
        public CustomerDetailViewModel CustomerDetailViewModel { get; set; }
        public CustomerEditViewModel CustomerEditViewModel { get; set; }
        public CustomerListViewModel CustomerListViewModel { get; set; }
    }
}
