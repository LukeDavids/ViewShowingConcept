using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Droid.Support.V7.Fragging.Fragments;

namespace ViewShowingConcept.Core.Interfaces
{
    public interface ISubView 
    {
        MvxFragment Fragment { get; set; }
        
    }
}
