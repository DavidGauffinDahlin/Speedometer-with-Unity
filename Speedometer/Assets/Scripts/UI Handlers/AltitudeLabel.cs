using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AltitudeLabel : MonoBehaviour 
{	
	Speedometer speedometer;
	Text text;

	private void Start()
	{
		speedometer = FindObjectOfType<Speedometer>();
		text = GetComponent<Text>();
	}

	void Update () 
	{
		if (!speedometer.hasLocationAccess) 
		{
			text.text="Altitude unknown";
			return;
		}

		double altitude = System.Math.Round(speedometer.altitude, 1);

		text.text = altitude.ToString() + " m (MSL) ";
	}
}
