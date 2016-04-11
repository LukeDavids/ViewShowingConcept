using System.Diagnostics;
using System.Threading.Tasks;
using MvvmCross.Core.Platform;
using MvvmCross.Core.ViewModels;
using MvvmCross.Core.Views;
using MvvmCross.Platform;
using ViewShowingConcept.Core.Enums;
using ViewShowingConcept.Core.Helpers;
using ViewShowingConcept.Core.Models;
using ViewShowingConcept.Core.ViewModels.Container;

namespace ViewShowingConcept.Core.ViewModels.Base
{
    public class BaseViewModel : MvxViewModel
    {
        public BaseViewModel() { 
        }

        private bool _isBusy;
        private ContainerViewModel _containerViewModel;

        public ContainerViewModel ContainerViewModel => ContainerViewModelHelper.ContainerViewModel;

        public bool IsBusy { get { return _isBusy; } set { _isBusy = value; RaisePropertyChanged(() => IsBusy); } }

        public void ShowView(ViewType viewType, ViewFrame viewFrame, string parameter)
        {
            if (ContainerViewModel != null)
            {
                ContainerViewModel.ShowViewEvent = new ShowViewEvent(viewType, viewFrame, parameter);
            }
            else {
                //ContainerViewModel = Mvx.Resolve<ContainerViewModel>();
                ContainerViewModel.Test = " test string from base view ";
                ContainerViewModel.ShowViewEvent = new ShowViewEvent(viewType, viewFrame, parameter);
            }
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
 
        public static void ShowViewModel<T>(dynamic parameter) where T : IMvxViewModel
        {
            var viewDispatcher = Mvx.Resolve<IMvxViewDispatcher>();
            var request = MvxViewModelRequest.GetDefaultRequest(typeof(T));
            request.ParameterValues = ((object)parameter).ToSimplePropertyDictionary();
            viewDispatcher.ShowViewModel(request);
        }
    }
}