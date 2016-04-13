using MvvmCross.Droid.Support.V7.Fragging.Fragments;
using MvvmCross.Platform;
using ViewShowingConcept.Android.Interfaces;
using ViewShowingConcept.Core.Enums;
using ViewShowingConcept.Core.ViewModels.Base;

namespace ViewShowingConcept.Android.Views.Base
{
    public class BaseView<TViewModel> : MvxFragment<TViewModel>, IAndroidView where TViewModel : BaseViewModel, new()
    {
        public BaseView()
        {
            ViewModel = Mvx.Resolve<TViewModel>();
            BaseViewModel = Mvx.Resolve<BaseViewModel>();
        }

        public BaseViewModel BaseViewModel { get; }
        public MvxFragment Fragment => this;
        public ViewType ViewType { get; set; }
        public string ViewTag { get; set; }
    }
}