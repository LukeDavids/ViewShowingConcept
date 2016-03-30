package md5686914bec1dd720f019be98cb06dedc7;


public class BaseView
	extends md58dddb99dd2ee29b3aeb18d99ad828118.MvxFragment
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("ViewShowingConcept.Android.Views.Base.BaseView, ViewShowingConcept.Android, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", BaseView.class, __md_methods);
	}


	public BaseView () throws java.lang.Throwable
	{
		super ();
		if (getClass () == BaseView.class)
			mono.android.TypeManager.Activate ("ViewShowingConcept.Android.Views.Base.BaseView, ViewShowingConcept.Android, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
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
