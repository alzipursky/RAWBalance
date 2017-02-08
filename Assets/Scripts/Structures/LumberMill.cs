using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LumberMill : Structure {

	// Use this for initialization
	void Start () {
		price = 30000;
		fixedOperatingCosts = 50;
	}
	
	// Update is called once per frame
	void Update () {
		if (built) {
			var gold = PlayerPrefs.GetInt("gold");
			PlayerPrefs.SetInt("gold", gold - (int)((float)fixedOperatingCosts*Time.deltaTime));
		}
	}
}
