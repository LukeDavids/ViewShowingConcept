using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using ViewShowingConcept.Core.Enums;

namespace ViewShowingConcept.Core.ViewModels.Container
{
    public class ContainerViewModel : MvxViewModel
    {
        private ViewType _currentView;

        public ContainerViewModel()
        {
            RegisterViewModels();
        }

        public ViewType CurrentView { get { return _currentView; } set { _currentView = value; RaisePropertyChanged(() => CurrentView); } }

        private void RegisterViewModels()
        {
            Mvx.LazyConstructAndRegisterSingleton(() => new CustomerDetailViewModel {ContainerViewModel = this});
            Mvx.LazyConstructAndRegisterSingleton(() => new CustomerEditViewModel { ContainerViewModel = this });
            Mvx.LazyConstructAndRegisterSingleton(() => new CustomerListViewModel { ContainerViewModel = this });
            Mvx.LazyConstructAndRegisterSingleton(() => new LoginViewModel { ContainerViewModel = this });
        }
      
        
    }
}
