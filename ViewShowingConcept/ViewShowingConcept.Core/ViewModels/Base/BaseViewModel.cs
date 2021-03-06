﻿using System.Threading.Tasks;
using MvvmCross.Core.Platform;
using MvvmCross.Core.ViewModels;
using MvvmCross.Core.Views;
using MvvmCross.Platform;
using ViewShowingConcept.Core.Enums;
using ViewShowingConcept.Core.Models;
using ViewShowingConcept.Core.ViewModels.Container;

namespace ViewShowingConcept.Core.ViewModels.Base
{
    public class BaseViewModel : MvxViewModel
    {
        private bool _isBusy;
        public ContainerViewModel ContainerViewModel => Mvx.Resolve<ContainerViewModel>();

        public bool IsBusy
        {
            get { return _isBusy; }
            set { _isBusy = value; RaisePropertyChanged(() => IsBusy); }
        }

        public void ShowView(ViewType viewType, ViewFrame viewFrame, string parameter, object[] args)
        {
            ContainerViewModel.ShowViewEvent = new ShowViewEvent(viewType, viewFrame, parameter, args);
        }

        public void ShowView(ViewType viewType, ViewFrame viewFrame, string parameter)
        {
            ContainerViewModel.ShowViewEvent = new ShowViewEvent(viewType, viewFrame, parameter);
        }

        public void ShowView(ViewType viewType, ViewFrame viewFrame)
        {
            ShowView(viewType, viewFrame, "none");
        }

        public void ViewDidShow(ViewType viewType, ViewFrame viewFrame, string parameter, object[] args)
        {
            ContainerViewModel.ViewDidShowEvent = new ViewDidShowEvent(viewType, viewFrame, parameter, args);
        }

        public void ViewDidShow(ViewType viewType, ViewFrame viewFrame, string parameter)
        {
            ContainerViewModel.ViewDidShowEvent = new ViewDidShowEvent(viewType, viewFrame, parameter);
        }

        public void ViewDidShow(ViewType viewType, ViewFrame viewFrame)
        {
            ViewDidShow(viewType, viewFrame, "none");
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
            var request = MvxViewModelRequest.GetDefaultRequest(typeof (T));
            request.ParameterValues = ((object) parameter).ToSimplePropertyDictionary();
            viewDispatcher.ShowViewModel(request);
        }
    }
}