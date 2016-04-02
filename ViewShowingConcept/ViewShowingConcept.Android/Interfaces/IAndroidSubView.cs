using MvvmCross.Droid.Support.V7.Fragging.Fragments;
using ViewShowingConcept.Core.Enums;
using ViewShowingConcept.Core.ViewModels.Base;

namespace ViewShowingConcept.Android.Interfaces
{
    public interface IAndroidSubView 
    {
        MvxFragment Fragment { get; }
        BaseViewModel BaseViewModel { get; }
        SubViewType SubViewType { get; }
        string SubViewTag { get; set; }


    }
}
