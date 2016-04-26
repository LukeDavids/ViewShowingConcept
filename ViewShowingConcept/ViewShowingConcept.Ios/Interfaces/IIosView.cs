
using System.Security.Cryptography.X509Certificates;
using MvvmCross.iOS.Views;
using ViewShowingConcept.Core.Enums;
using ViewShowingConcept.Core.ViewModels.Base;

namespace ViewShowingConcept.Ios.Interfaces
{
    public interface IIosView
    {
        BaseViewModel BaseViewModel { get; }
        IMvxIosView Controller { get; }
        ViewType ViewType { get; }
        string ViewTag { get; set; }
        int ChildNum { get; set; }

    }
}
