using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeControl : MonoBehaviour {

	public Dropdown dropDown;

	// this is a singleton class
	private TimeControl timeControlScript;
	// frame rate ~0.02 seconds, so every 0.02 seconds add 2000 seconds to date -> a little more than one day per second
	private float timeAccelerator = 100000f;
	private string date;

	private bool added = false;

	private float elapsedTime = 0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
//		date = PlayerPrefs.GetString("date", date);

		if (elapsedTime > 1f) {
			date = PlayerPrefs.GetString("date", date);

			DateTime savedDate = DateTime.Parse(date,System.Globalization.CultureInfo.InvariantCulture);
			savedDate = savedDate.AddDays(1);
			date = savedDate.ToString("MMMM dd, yyyy");

			PlayerPrefs.SetString("date", date);

			//would deplete the forest right here also
			elapsedTime = 0f;
		} else {
			elapsedTime += Time.deltaTime;
		}

//		DateTime savedDate = DateTime.Parse(date,System.Globalization.CultureInfo.InvariantCulture);
//		savedDate = savedDate.AddSeconds((double)Time.deltaTime*timeAccelerator);
//		date = savedDate.ToString(System.Globalization.CultureInfo.InvariantCulture);
//
//		PlayerPrefs.SetString("date", date);

//		if (!added) {
//			added = true;
//			dropDown.options.Add (new Dropdown.OptionData() {text="c"});
//		}

	}
}
