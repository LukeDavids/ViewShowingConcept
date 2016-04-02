using System;
using System.Collections.Generic;
using MvvmCross.Core.ViewModels;
using ViewShowingConcept.Core.Config;
using ViewShowingConcept.Core.Enums;
using ViewShowingConcept.Core.Interfaces;

namespace ViewShowingConcept.Core.ViewModels.Base
{
    public class BaseViewModel : MvxViewModel
    {

        //public virtual void Init(string currentEntityId)
        //{
        //    if (string.IsNullOrEmpty(currentEntityId)) return;
        //}

        private bool _isBusy;
        private SubViewType _currentSubView;

        public bool IsBusy { get { return _isBusy; } set { _isBusy = value; RaisePropertyChanged(() => IsBusy); } }
        public SubViewType CurrentSubView { get { return _currentSubView; } set { _currentSubView = value; RaisePropertyChanged(() => CurrentSubView); } }
        public Dictionary<SubViewType, BaseViewModel> SubViewModels { get; set; }

        public void ShowSubView(SubViewType subView)
        {
            ShowSubView(subView, "");
        }
        public void ShowSubView(SubViewType subView, string parameter)
        {
            CurrentSubView = subView;
            if (CurrentSession.BuildPlatform != BuildPlatform.iOS) return;
            switch (CurrentSubView)
            {
                case SubViewType.CustomerDetails:
                    ShowViewModel<CustomerDetailViewModel>(new { parameter });
                    break;
                case SubViewType.CustomerEdit:
                    ShowViewModel<CustomerEditViewModel>(new { parameter });
                    break;
                case SubViewType.CustomerList:
                    ShowViewModel<CustomerListViewModel>();
                    break;
                case SubViewType.Login:
                    ShowViewModel<LoginViewModel>();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}