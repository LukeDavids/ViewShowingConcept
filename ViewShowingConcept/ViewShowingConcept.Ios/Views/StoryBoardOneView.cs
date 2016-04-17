using System;
using System.Drawing;

using CoreFoundation;
using UIKit;
using Foundation;
using MvvmCross.Binding.BindingContext;
using ViewShowingConcept.Core.Enums;
using ViewShowingConcept.Core.ViewModels;
using ViewShowingConcept.Ios.Views.Base;
using ViewShowingConcept.Core;
using MvvmCross.iOS.Views;



namespace ViewShowingConcept.Ios.Views
{
	[Register("StoryBoardOneView")]
	public class StoryBoardOneView : BaseView<StoryBoardOneViewModel>
	{
		public StoryBoardOneView ()
		{
			ViewType = ViewType.StoryBoardOneView;
			ViewTag = ViewType.ToString();
		}

		public StoryBoardOneView(IntPtr handle) : base(handle)
		{

		}

		public override void ShowViewModel()
		{
			ViewModel.ShowViewModel();
		}

		public override void AwakeFromNib ()
		{
			// Called when loaded from xib or storyboard.

//			this.Initialize ();
		}

		public override void DidReceiveMemoryWarning()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning();

			// Release any cached data, images, etc that aren't in use.
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad ();
		}
	}
}

