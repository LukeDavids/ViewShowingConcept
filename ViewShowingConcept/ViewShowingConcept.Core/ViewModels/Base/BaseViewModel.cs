using System;
using System.Collections.Generic;
using MvvmCross.Core.ViewModels;
using ViewShowingConcept.Core.Enums;

namespace ViewShowingConcept.Core.ViewModels.Base
{
    public class BaseViewModel : MvxViewModel
    {

        public virtual void Init(string currentEntityId)
        {
            if (string.IsNullOrEmpty(currentEntityId)) return;
        }

        private bool _isBusy;
        private SubView _currentSubView;

        public bool IsBusy { get { return _isBusy; } set { _isBusy = value; RaisePropertyChanged(() => IsBusy); } }
        public SubView CurrentSubView { get { return _currentSubView; } set { _currentSubView = value; RaisePropertyChanged(() => CurrentSubView); } }
        public Dictionary<SubView, BaseViewModel> SubViewModels { get; set; }

        public void ShowSubView(SubView subView)
        {
            ShowSubView(subView, "");
        }
        public void ShowSubView(SubView subView, string parameter)
        {
            CurrentSubView = subView;
            //if (CurrentSession.BuildPlatform != BuildPlatform.iOS) return;
            switch (CurrentSubView)
            {
                case SubView.CustomerDetails:
                    ShowViewModel<CustomerDetailViewModel>(new { parameter });
                    break;
                case SubView.CustomerEdit:
                    ShowViewModel<CustomerEditViewModel>(new { parameter });
                    break;
                case SubView.CustomerList:
                    ShowViewModel<CustomerListViewModel>();
                    break;
                case SubView.Login:
                    ShowViewModel<LoginViewModel>();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}