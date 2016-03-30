using System;
using Android.Content;
using MvvmCross.Droid.Platform;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform.Platform;

namespace ViewShowingConcept.Android
{
        public interface ICustomPresenter
        {
            void Register(Type viewModelType, IFragmentHost host);
        }
    }
