using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.WindowsUWP.Views;
using ViewShowingConcept.Core.Enums;
using ViewShowingConcept.Core.ViewModels.Base;

namespace ViewShowingConcept.Windows.Interfaces
{
    public interface IWindowsView
    {
        BaseViewModel BaseViewModel { get; }
        IMvxWindowsView Page { get; }
        ViewType ViewType { get; }
        string ViewTag { get; set; }
    }
}
