using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TopBarScript : MonoBehaviour {

	private int gold;
	private int wood;
	private string date;

	public Text TopBar;


	// Use this for initialization
	void Start () {
		PlayerPrefs.SetInt ("gold", 50000);
		PlayerPrefs.SetInt ("wood", 0);
		PlayerPrefs.SetString("date", "1/1/1700");
	}
	
	// Update is called once per frame
	void Update () {
		gold = PlayerPrefs.GetInt ("gold", gold);
		wood = PlayerPrefs.GetInt ("wood", wood);
		date = PlayerPrefs.GetString("date", date);

		TopBar.text = string.Format("Gold: {0}   |   Wood: {1}   |   Date: {2}", gold, wood,date);
	
	}
}
