using System;
using System.Drawing;

using CoreFoundation;
using UIKit;
using Foundation;
using MvvmCross.Binding.BindingContext;
using ViewShowingConcept.Core.Enums;
using ViewShowingConcept.Core.ViewModels;
using ViewShowingConcept.Ios.Views.Base;

namespace ViewShowingConcept.Ios.Views
{
	[Register("FirstScreenView")]
	public class FirstScreenView : BaseView<CustomerDetailViewModel>
	{
		public FirstScreenView ()
		{
			ViewType = ViewType.FirstStoryboardView;
			ViewTag = ViewType.ToString();
		}
			
		public override void ShowViewModel()
		{
			ViewModel.ShowViewModel();
		}
			
		public override void DidReceiveMemoryWarning()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning();

			// Release any cached data, images, etc that aren't in use.
		}





	}
}

