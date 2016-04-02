using MvvmCross.Droid.Support.V7.Fragging.Fragments;
using MvvmCross.Platform;
using ViewShowingConcept.Core.Enums;
using ViewShowingConcept.Core.Interfaces;
using ViewShowingConcept.Core.ViewModels.Base;
using IAndroidSubView = ViewShowingConcept.Android.Interfaces.IAndroidSubView;

namespace ViewShowingConcept.Android.Views.Base
{
    public class BaseSubView<TViewModel> : MvxFragment<TViewModel>, IAndroidSubView where TViewModel : BaseViewModel, new()
    {

        public BaseSubView(SubViewType subViewType)
        {
            ViewModel = Mvx.Resolve<TViewModel>();
            SubViewType = subViewType;
            SubViewTag = subViewType.ToString();
        }
        
        public MvxFragment Fragment => this;
        public BaseViewModel BaseViewModel => ViewModel as BaseViewModel;
        public SubViewType SubViewType { get; set; }
        public string SubViewTag { get; set; }
    }
}