using System.Collections.Generic;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using ViewShowingConcept.Core.Enums;
using ViewShowingConcept.Core.Models;
using ViewShowingConcept.Core.ViewModels.Base;
using static ViewShowingConcept.Core.Enums.ViewType;

namespace ViewShowingConcept.Core.ViewModels.Container
{
    public class ContainerViewModel : MvxViewModel
    {
        public ContainerViewModel()
        {
			
            RegisterViewModels();
            Mvx.RegisterSingleton(() => this);
        }

        public Dictionary<ViewType, BaseViewModel> ViewModels { get; set; }

        private ShowViewEvent _showViewEvent;

        public ShowViewEvent ShowViewEvent
        {
            get { return _showViewEvent; }
            set
            {
                _showViewEvent = value;
                RaisePropertyChanged(() => ShowViewEvent);
            }
        }

        public Stack<ViewType> CustomBackStack { get; set; }

        private void RegisterViewModels()
        {
			Mvx.LazyConstructAndRegisterSingleton(() => BaseViewModel.BaseInstance);
			Mvx.LazyConstructAndRegisterSingleton(() => CustomerDetailViewModel.Instance);
			Mvx.LazyConstructAndRegisterSingleton(() => CustomerEditViewModel.Instance);
			Mvx.LazyConstructAndRegisterSingleton(() => CustomerListViewModel.Instance);
			Mvx.LazyConstructAndRegisterSingleton(() => CustomerViewModel.Instance);
			Mvx.LazyConstructAndRegisterSingleton(() => CustomerSplitViewModel.Instance);
			Mvx.LazyConstructAndRegisterSingleton(() => TabbedViewModel.Instance);
			Mvx.LazyConstructAndRegisterSingleton(() => DummyTab1ViewModel.Instance);
			Mvx.LazyConstructAndRegisterSingleton(() => DummyTab2ViewModel.Instance);
			Mvx.LazyConstructAndRegisterSingleton(() => DummyTab3ViewModel.Instance);

            ViewModels = new Dictionary<ViewType, BaseViewModel>
            {
				
				{CustomerDetails, Mvx.Resolve<CustomerDetailViewModel>()},
                {CustomerEdit, Mvx.Resolve<CustomerEditViewModel>()},
                {CustomerList, Mvx.Resolve<CustomerListViewModel>()},
                {CustomerView, Mvx.Resolve<CustomerViewModel>()},
                {CustomerSplit, Mvx.Resolve<CustomerSplitViewModel>()},
                {TabbedView, Mvx.Resolve<TabbedViewModel>()},
                {DummyTab1View, Mvx.Resolve<DummyTab1ViewModel>()},
                {DummyTab2View, Mvx.Resolve<DummyTab2ViewModel>()},
                {DummyTab3View, Mvx.Resolve<DummyTab3ViewModel>()}
            };
        }
    }
}
