using System;
using System.Collections.Generic;
using System.Text;
using MvvmCross.Binding;
using MvvmCross.Binding.Bindings.Target;
using MvvmCross.Binding.iOS.Target;
using MvvmCross.Core.ViewModels;

namespace ViewShowingConcept.Ios.Bindings
{
    public class MasterDetailMasterBinding
        : MvxTargetBinding
    {
        private IMvxViewModel Master;
        public MasterDetailMasterBinding(IMvxViewModel target) : base(target)
        {
        }

        public override MvxBindingMode DefaultMode
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override Type TargetType
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override void SetValue(object value)
        {
            throw new NotImplementedException();
        }
    }
}
