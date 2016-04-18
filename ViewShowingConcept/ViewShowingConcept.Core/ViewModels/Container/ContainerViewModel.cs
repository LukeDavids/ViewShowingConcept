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
            Mvx.LazyConstructAndRegisterSingleton(() => new BaseViewModel());
            Mvx.LazyConstructAndRegisterSingleton(() => new CustomerDetailViewModel());
            Mvx.LazyConstructAndRegisterSingleton(() => new CustomerEditViewModel());
            Mvx.LazyConstructAndRegisterSingleton(() => new CustomerListViewModel());
            Mvx.LazyConstructAndRegisterSingleton(() => new CustomerViewModel());
            Mvx.LazyConstructAndRegisterSingleton(() => new CustomerSplitViewModel());
            Mvx.LazyConstructAndRegisterSingleton(() => new TabbedViewModel());
            Mvx.LazyConstructAndRegisterSingleton(() => new DummyTab1ViewModel());
            Mvx.LazyConstructAndRegisterSingleton(() => new DummyTab2ViewModel());
            Mvx.LazyConstructAndRegisterSingleton(() => new DummyTab3ViewModel());

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
