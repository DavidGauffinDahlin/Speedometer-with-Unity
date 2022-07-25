using UnityEngine;
using System.Collections;
using UnityEngine.Android;

/*
 * Stolen and slightly modified version from: 
 * https://github.com/eelstork/Unity-Speedometer
 */

/* Speedometer uses this to start location services */
public class LocationServiceHandler : MonoBehaviour {

	// Let system popup be displayed to enable location services?
	public bool enableByRequest = true;

	// How long to wait before giving up starting the service (seconds)
	public int maxWait = 10;

	[Header("Only for Debugging purposes, (read only, do not edit)")] // ----------------------------
	// Value set by this class to indicate service is ready to used
	public bool ready = false;

	public LocationService service = Input.location;

    private void Update()
    {
        if (service.status == LocationServiceStatus.Running)
        {
			print(service.lastData.horizontalAccuracy);
			print(service.lastData.verticalAccuracy);
        }
    }

    public void StartGPSLocationService()
    {
		StartCoroutine(StartGPS());
    }

	public void StopGPSLocationService()
    {
		if (service.status == LocationServiceStatus.Running)
        {
			service.Stop();
        }
    }
	
	IEnumerator StartGPS(){

		// First, check if user has location service enabled
		// (If not enabled, OS may display a popup to authorize it)
		if (!enableByRequest && !service.isEnabledByUser) {
			Debug.Log("Location Services not enabled by user");
			yield break;
		}

		// Make sure Android users uses fine precision location
		if (!Permission.HasUserAuthorizedPermission(Permission.FineLocation))
		{
			Permission.RequestUserPermission(Permission.FineLocation);
			Permission.RequestUserPermission(Permission.CoarseLocation);
		}

		// Start service before querying location
		service.Start();

		// Wait until service initializes
		while (service.status == LocationServiceStatus.Initializing && maxWait > 0) {
			yield return new WaitForSeconds(1);
			maxWait--;
		}

		// Service didn't initialize in 20 seconds
		if (maxWait < 1){
			Debug.Log("Timed out");
			yield break;
		}

		// Connection has failed
		if (service.status == LocationServiceStatus.Failed) {
			Debug.Log("Unable to determine device location");
			yield break;
		} else {
			// Access granted and location value could be retrieved
			Debug.Log("Gps Access Granted. Location: " + service.lastData.latitude + " " + service.lastData.longitude + " " + service.lastData.altitude + " " + service.lastData.horizontalAccuracy + " " + service.lastData.timestamp);
		}

		// Stop service if there is no need to query location updates continuously
		//service.Stop();
		Debug.Log("Service started");

		ready = true;
	}
}