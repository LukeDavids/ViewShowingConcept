using MvvmCross.Droid.Support.V7.Fragging.Fragments;
using ViewShowingConcept.Core.Enums;
using ViewShowingConcept.Core.ViewModels.Base;

namespace Onsight.Android.Views.Base
{
    public class BaseView : MvxFragment
    {
        public BaseViewModel BaseViewModel => ViewModel as BaseViewModel;
        public SubView SubViewType { get; set; }
    }
}