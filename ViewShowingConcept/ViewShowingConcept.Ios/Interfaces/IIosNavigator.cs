using System;
using System.Collections.Generic;
using System.Text;
using ViewShowingConcept.Core.Enums;
using ViewShowingConcept.Core.Models;

namespace ViewShowingConcept.Ios.Interfaces
{
    public interface IIosNavigator
    {
        ViewType CurrentSelected { get; set; }
        void UpdateView(ShowViewEvent showViewEvent);
    }
}
