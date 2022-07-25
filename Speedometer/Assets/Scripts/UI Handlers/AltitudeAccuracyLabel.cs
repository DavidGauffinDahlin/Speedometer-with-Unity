using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AltitudeAccuracyLabel : MonoBehaviour 
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
			text.text = "accuracy: NA";	
			return;
		}

		text.text = " accuracy: " + speedometer.altitudeAccuracy + " meters";
	}
}
