using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SpeedLabel : MonoBehaviour 
{
	Speedometer speedometer;
	Text text;
	int speed;

	private void Start()
	{
		speedometer = FindObjectOfType<Speedometer>();
		text = GetComponent<Text>();
	}

	void Update () 
	{
		speed = Mathf.RoundToInt(speedometer.speedInKmPerHour);

		if (!speedometer.ready) {
			text.text = "Speed: N/A"; 
			return;
		}

		text.text = speed + " km/h";
	}
}
