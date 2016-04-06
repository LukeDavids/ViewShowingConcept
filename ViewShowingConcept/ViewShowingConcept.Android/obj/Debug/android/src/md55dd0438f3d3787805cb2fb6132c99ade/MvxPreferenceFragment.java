package md55dd0438f3d3787805cb2fb6132c99ade;


public abstract class MvxPreferenceFragment
	extends md580ef525d29c932c0d5916bfd064f52ac.MvxEventSourcePreferenceFragment
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("MvvmCross.Droid.FullFragging.Fragments.MvxPreferenceFragment, MvvmCross.Droid.FullFragging, Version=4.0.0.0, Culture=neutral, PublicKeyToken=null", MvxPreferenceFragment.class, __md_methods);
	}


	public MvxPreferenceFragment () throws java.lang.Throwable
	{
		super ();
		if (getClass () == MvxPreferenceFragment.class)
			mono.android.TypeManager.Activate ("MvvmCross.Droid.FullFragging.Fragments.MvxPreferenceFragment, MvvmCross.Droid.FullFragging, Version=4.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}

	java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
