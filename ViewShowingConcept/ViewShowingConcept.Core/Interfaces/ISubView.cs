
//using MvvmCross.Droid.FullFragging.Fragments;
using ViewShowingConcept.Core.Enums;
using ViewShowingConcept.Core.ViewModels.Base;

namespace ViewShowingConcept.Core.Interfaces
{
    public interface IAndroidSubView 
    {
        //MvxFragment Fragment { get; }
        BaseViewModel BaseViewModel { get; }
        ViewType SubViewType { get; }
        string Tag { get; }


    }
}
