using MvvmCross.Droid.Support.V7.Fragging.Fragments;
using MvvmCross.Platform;
using ViewShowingConcept.Core.Enums;
using ViewShowingConcept.Core.Interfaces;
using ViewShowingConcept.Core.ViewModels.Base;
using IAndroidSubView = ViewShowingConcept.Android.Interfaces.IAndroidSubView;

namespace ViewShowingConcept.Android.Views.Base
{
    public class BaseView<TViewModel> : MvxFragment<TViewModel>, IAndroidSubView where TViewModel : BaseViewModel, new()
    {

        public BaseView(ViewType subViewType)
        {
            ViewModel = Mvx.Resolve<TViewModel>();
            SubViewType = subViewType;
            SubViewTag = subViewType.ToString();
        }
        
        public MvxFragment Fragment => this;
        public BaseViewModel BaseViewModel => ViewModel as BaseViewModel;
        public ViewType SubViewType { get; set; }
        public string SubViewTag { get; set; }
    }
}