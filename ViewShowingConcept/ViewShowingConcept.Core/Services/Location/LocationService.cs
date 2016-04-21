using System;
using MvvmCross.Plugins.Location;
using MvvmCross.Plugins.Messenger;
using MvvmCross.Platform;
using System.Collections.Generic;

namespace ViewShowingConcept.Core
{
	public class LocationService : ILocationService
	{
		private readonly IMvxLocationWatcher _watcher;
		private readonly IMvxMessenger _messenger;


		public LocationService (IMvxLocationWatcher watcher, IMvxMessenger messenger)
		{
			_watcher = watcher;
			_messenger = messenger;
			_watcher.Start (new MvxLocationOptions (), OnLocation, OnError);
		}

		public void OnLocation(MvxGeoLocation location)
		{
			var message = new LocationMessage (this, 
				              location.Coordinates.Latitude,
				              location.Coordinates.Longitude);

			_messenger.Publish (message);
		}

		public void OnError(MvxLocationError error)
		{
			Mvx.Error ("Seen location error {0}", error.Code);
		}
	}
}

