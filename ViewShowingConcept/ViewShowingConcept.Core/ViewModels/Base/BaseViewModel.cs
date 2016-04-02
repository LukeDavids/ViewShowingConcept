using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
using ViewShowingConcept.Core.Enums;
using ViewShowingConcept.Core.Models;
using ViewShowingConcept.Core.ViewModels.Container;

namespace ViewShowingConcept.Core.ViewModels.Base
{
    public class BaseViewModel : MvxViewModel
    {
        
        private bool _isBusy;
        public ContainerViewModel ContainerViewModel { get; set; }
        public bool IsBusy { get { return _isBusy; } set { _isBusy = value; RaisePropertyChanged(() => IsBusy); } }

        public void ShowView(ViewType viewType, ViewFrame viewFrame, string parameter)
        {
            ContainerViewModel.ShowViewEvent = new ShowViewEvent(viewType, viewFrame, parameter);
        }

        public void ShowView(ViewType viewType, ViewFrame viewFrame)
        {
            ShowView(viewType, viewFrame, "none");
        }

        public IMvxCommand InitialiseCommand => new MvxAsyncCommand<ShowViewEvent>(Initialise);

        public virtual async Task Initialise(ShowViewEvent viewEvent)
        {
            if (ContainerViewModel == null || ContainerViewModel.ViewModels == null) return;
            ContainerViewModel.ViewModels[viewEvent.ViewType].InitialiseCommand.Execute(viewEvent);
        }

    }
}