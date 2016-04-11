using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;
using MvvmCross.Core.ViewModels;
using MvvmCross.Core.Views;
using MvvmCross.Droid.Support.V4;
using MvvmCross.Platform;
using FragmentManager = Android.Support.V4.App.FragmentManager;

namespace ViewShowingConcept.Android.Adapters
{
    public class ViewPagerAdapter: MvxFragmentPagerAdapter
    {
        private Context _context;

        public ViewPagerAdapter(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        public ViewPagerAdapter(Context context, FragmentManager fragmentManager, IEnumerable<FragmentInfo> fragments) : base(context, fragmentManager, fragments)
        {
        }
        public override Fragment GetItem(int position)
        {
            var fragInfo = Fragments.ElementAt(position);

            if (fragInfo.CachedFragment == null)
            {
                fragInfo.CachedFragment = Fragment.Instantiate(_context, FragmentJavaName(fragInfo.FragmentType));

                var request = new MvxViewModelRequest(fragInfo.ViewModelType, null, null, null);
                ((IMvxView) fragInfo.CachedFragment).ViewModel = Mvx.Resolve<IMvxViewModelLoader>().LoadViewModel(request, null);
            }

            return fragInfo.CachedFragment;
        }
    }
}