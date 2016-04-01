using MvvmCross.Droid.Support.V7.Fragging.Fragments;
using ViewShowingConcept.Core.Enums;
using ViewShowingConcept.Core.Interfaces;
using ViewShowingConcept.Core.ViewModels.Base;

namespace ViewShowingConcept.Android.Views.Base
{
    public class BaseView<TViewModel> : MvxFragment<TViewModel> where TViewModel : BaseViewModel, ISubView
    {
        public BaseViewModel BaseViewModel => ViewModel as BaseViewModel;
        public SubView SubViewType { get; set; } 
    }
}