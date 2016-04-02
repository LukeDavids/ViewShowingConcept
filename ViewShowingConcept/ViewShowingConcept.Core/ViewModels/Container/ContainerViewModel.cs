using System.Collections.Generic;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using ViewShowingConcept.Core.Enums;
using ViewShowingConcept.Core.Models;
using ViewShowingConcept.Core.ViewModels.Base;

namespace ViewShowingConcept.Core.ViewModels.Container
{
    public class ContainerViewModel : MvxViewModel
    {

        public ContainerViewModel()
        {
            RegisterViewModels();
        }
        
        public Dictionary<ViewType, BaseViewModel> ViewModels { get; set; }

        private ShowViewEvent _showViewEvent;
        public ShowViewEvent ShowViewEvent {
            get { return _showViewEvent; }
            set { _showViewEvent = value; RaisePropertyChanged(() => ShowViewEvent); }
        }

        private void RegisterViewModels()
        {
            Mvx.LazyConstructAndRegisterSingleton(() => new BaseViewModel { ContainerViewModel = this });
            Mvx.LazyConstructAndRegisterSingleton(() => new CustomerDetailViewModel {ContainerViewModel = this});
            Mvx.LazyConstructAndRegisterSingleton(() => new CustomerEditViewModel { ContainerViewModel = this });

            ViewModels = new Dictionary<ViewType, BaseViewModel>
            {
                {ViewType.CustomerDetails, Mvx.Resolve<CustomerDetailViewModel>()},
                {ViewType.CustomerEdit, Mvx.Resolve<CustomerEditViewModel>()}
            };
        }
      
        
    }
}
