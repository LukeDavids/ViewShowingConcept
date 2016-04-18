package md55a74d23b11a0c14e53237f361ce422d4;


public class ContainerView
	extends md5204979768ea66d3a79201c4efd7c602a.MvxCachingFragmentCompatActivity_1
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"n_onBackPressed:()V:GetOnBackPressedHandler\n" +
			"";
		mono.android.Runtime.register ("ViewShowingConcept.Android.Views.ContainerView.ContainerView, ViewShowingConcept.Android, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", ContainerView.class, __md_methods);
	}


	public ContainerView () throws java.lang.Throwable
	{
		super ();
		if (getClass () == ContainerView.class)
			mono.android.TypeManager.Activate ("ViewShowingConcept.Android.Views.ContainerView.ContainerView, ViewShowingConcept.Android, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);


	public void onBackPressed ()
	{
		n_onBackPressed ();
	}

	private native void n_onBackPressed ();

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
