using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Support.V7.Fragging.Fragments;
using MvvmCross.Platform;
using System;
using ViewShowingConcept.Core.Enums;
using ViewShowingConcept.Core.Interfaces;
using ViewShowingConcept.Core.ViewModels.Base;
using ViewShowingConcept.Core.ViewModels.Container;
using IAndroidView = ViewShowingConcept.Android.Interfaces.IAndroidView;

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