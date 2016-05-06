using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Platform.Platform;
using MvvmCross.Test.Core;
using NUnit.Framework;
using MvvmCross.Core;
using MvvmCross;
using ViewShowingConcept.Core.ViewModels;

namespace ViewShowingConcept.Core.IntegrationTests
{
    [TestFixture]
    public class Class1 : MvxTest
    {
        [Test]
        public void ShowTabsCausesNavigation()
        {
            ClearAll();

            var mockNavigation = CreateMockNavigation();
            var viewModel = new CustomerDetailViewModel();
            viewModel.ShowTabbedCommand.Execute();
            Assert.AreEqual(1,mockNavigation.NavigateRequests.Count);
        }
    }
}
