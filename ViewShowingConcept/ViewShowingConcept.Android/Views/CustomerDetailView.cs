using Android.OS;
using Android.Runtime;
using Android.Views;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.Droid.BindingContext;
using ViewShowingConcept.Android.Views.Base;
using ViewShowingConcept.Core.Enums;
using ViewShowingConcept.Core.ViewModels;

namespace ViewShowingConcept.Android.Views
{
    [Register("ViewShowingConcept.android.views.CustomerDetailSubView")]
    public class CustomerDetailView : BaseView<CustomerDetailViewModel>
    {
        private ViewType _currentView;

        public CustomerDetailView(ViewType subViewType) : base(subViewType)
        {
        }

        public override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
        }

        public override void OnViewModelSet()
        {
            base.OnViewModelSet();
            //this.CreateBinding(this)
            //    .For(view => view.CurrentView)
            //    .To<CustomerDetailViewModel>(vm => vm.CurrentView)
            //    .Apply();   
        }

        public ViewType CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                //ShowFragment(SubViews[_currentSubView]);
            }
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            var ignored = base.OnCreateView(inflater, container, savedInstanceState);
            return this.BindingInflate(Resource.Layout.CustomerDetailView, null);
        }

    }
}
