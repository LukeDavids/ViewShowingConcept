using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;

namespace ViewShowingConcept.Core.Interfaces
{
    public interface ITab
    {
        IMvxViewModel Page { get; }
        string Name { get; set; }
        string Image { get; set; }
    }
}
