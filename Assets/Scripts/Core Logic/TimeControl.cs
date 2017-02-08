using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeControl : MonoBehaviour {


	// this is a singleton class
	private TimeControl timeControlScript;
	// frame rate ~0.02 seconds, so every 0.02 seconds add 2000 seconds to date -> a little more than one day per second
	private float timeAccelerator = 100000f;
	private string date;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		date = PlayerPrefs.GetString("date", date);

		DateTime savedDate = DateTime.Parse(date,System.Globalization.CultureInfo.InvariantCulture);
		savedDate = savedDate.AddSeconds((double)Time.deltaTime*timeAccelerator);
		date = savedDate.ToString(System.Globalization.CultureInfo.InvariantCulture);

		PlayerPrefs.SetString("date", date);
	}
}
