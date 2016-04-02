using System;
using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Support.V7.Fragging.Fragments;
using ViewShowingConcept.Core.Enums;
using ViewShowingConcept.Core.ViewModels.Base;

namespace ViewShowingConcept.Android.Interfaces
{
    public interface IAndroidView
    {
        BaseViewModel BaseViewModel { get; }
        MvxFragment Fragment { get; }
        ViewType ViewType { get; }
        string ViewTag { get; set; }

    }
}
