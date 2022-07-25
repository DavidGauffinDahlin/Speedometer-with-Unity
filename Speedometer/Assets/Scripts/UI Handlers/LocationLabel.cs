using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LocationLabel : MonoBehaviour 
{
	// format: "40.446° N 79.982° W"
	
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
			text.text="Location unknown";
			return;
		}

		text.text = speedometer.latitude.ToString ("F6") + "° N "
		+ speedometer.longitude.ToString ("F6") + "° W";
	}
}
