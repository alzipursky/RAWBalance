using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TopBarScript : MonoBehaviour {

	private int gold;
	private int competitorsGold;
	private string date;

	public Text TopBar;


	// Use this for initialization
	void Start () {
		PlayerPrefs.SetInt ("gold", 50000);
		PlayerPrefs.SetInt ("competitorsGold", 20000);
		PlayerPrefs.SetString("date", "January 01, 1700");
	}
	
	// Update is called once per frame
	void Update () {
		gold = PlayerPrefs.GetInt ("gold");
		competitorsGold = PlayerPrefs.GetInt ("competitorsGold");

		date = PlayerPrefs.GetString("date");

		TopBar.text = string.Format("Your Gold: {0}   |   Competitor's Gold: {1}   |   Date: {2}", gold, competitorsGold, date);
	
	}
}
