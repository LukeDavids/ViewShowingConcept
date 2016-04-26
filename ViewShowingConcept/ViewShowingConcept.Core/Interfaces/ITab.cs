using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
using ViewShowingConcept.Core.Enums;

namespace ViewShowingConcept.Core.Interfaces
{
    public interface ITab
    {
        IMvxViewModel Page { get; }
        ViewType ViewType { get; }
        string Name { get; set; }
        string Image { get; set; }

        void AlertViewModel();
    }
}
