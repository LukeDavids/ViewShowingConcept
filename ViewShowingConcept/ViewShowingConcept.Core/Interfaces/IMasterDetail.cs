using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;

namespace ViewShowingConcept.Core.Interfaces
{
    public interface IMasterDetail
    {
        IMvxViewModel Master { get; set; }
        IMvxViewModel Detail { get; set; }
    }
}
