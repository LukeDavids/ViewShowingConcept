using System;
using System.Collections.Generic;
using MvvmCross.Core.ViewModels;
using ViewShowingConcept.Core.Config;
using ViewShowingConcept.Core.Enums;
using ViewShowingConcept.Core.Interfaces;
using ViewShowingConcept.Core.ViewModels.Container;

namespace ViewShowingConcept.Core.ViewModels.Base
{
    public class BaseViewModel : MvxViewModel
    {

        //public virtual void Init(string currentEntityId)
        //{
        //    if (string.IsNullOrEmpty(currentEntityId)) return;
        //}

        private bool _isBusy;
        public ContainerViewModel ContainerViewModel { get; set; }
        public bool IsBusy { get { return _isBusy; } set { _isBusy = value; RaisePropertyChanged(() => IsBusy); } }

       
    }
}