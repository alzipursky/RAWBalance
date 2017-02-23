using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TopBarScript : MonoBehaviour {

	private int gold;
	private string date;

	public Text TopBar;


	// Use this for initialization
	void Start () {
		PlayerPrefs.SetInt ("gold", 50000);
		PlayerPrefs.SetString("date", "January 01, 1700");
	}
	
	// Update is called once per frame
	void Update () {
		gold = PlayerPrefs.GetInt ("gold", gold);
		date = PlayerPrefs.GetString("date", date);

		TopBar.text = string.Format("Gold: {0}   |   Date: {1}", gold,date);
	
	}
}
