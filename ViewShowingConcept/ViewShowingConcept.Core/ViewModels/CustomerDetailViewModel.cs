using System.Windows.Input;
using MvvmCross.Core.ViewModels;
using ViewShowingConcept.Core.Enums;
using ViewShowingConcept.Core.ViewModels.Base;
using ViewShowingConcept.Core.ViewModels.Container;

namespace ViewShowingConcept.Core.ViewModels
{
    public class CustomerDetailViewModel : BaseViewModel
    {
        public string ButtonText => "Edit Customer";

        public ICommand ShowEditCommand => new MvxCommand(ShowEdit);
        private void ShowEdit()
        {
            ContainerViewModel.CurrentView = ViewType.CustomerEdit;
        }

    }
}
