using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Core.Views;
using MvvmCross.Platform.Core;
using MvvmCross.Test.Core;
using ViewShowingConcept.Core.IntegrationTests.Mocks;

namespace ViewShowingConcept.Core.IntegrationTests
{
    public class MvxTest : MvxIoCSupportingTest
    {
        protected MockMvxViewDispatcher CreateMockNavigation()
        {
            var dispatcher = new MockMvxViewDispatcher();
            Ioc.RegisterSingleton<IMvxMainThreadDispatcher>(dispatcher);
            Ioc.RegisterSingleton<IMvxViewDispatcher>(dispatcher);
            return dispatcher;
        }
    }
}
