using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeControl : MonoBehaviour {


	// this is a singleton class
	private TimeControl timeControlScript;
	private float elapsedTime = 0;
	private float timeAccelerator = 100f;
	private string date;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		elapsedTime += Time.deltaTime;

		date = PlayerPrefs.GetString("date", date);

		DateTime savedDate = DateTime.Parse(date,System.Globalization.CultureInfo.InvariantCulture);
		savedDate = savedDate.AddSeconds((double)elapsedTime*timeAccelerator);
		date = savedDate.ToString(System.Globalization.CultureInfo.InvariantCulture);

		PlayerPrefs.SetString("date", date);
	}
}
