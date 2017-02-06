using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TopBarScript : MonoBehaviour {

	int gold;
	int wood;
	float date;

	public Text TopBar;


	// Use this for initialization
	void Start () {
		PlayerPrefs.SetInt ("gold", 50000);
		PlayerPrefs.SetInt ("wood", 10);
		PlayerPrefs.SetFloat ("date", 0);
	}
	
	// Update is called once per frame
	void Update () {
		gold = PlayerPrefs.GetInt ("gold", gold);
		wood = PlayerPrefs.GetInt ("wood", wood);
		date = PlayerPrefs.GetFloat ("date", date);
		PlayerPrefs.SetFloat ("date", date + 1 * Time.deltaTime);

		TopBar.text = string.Format("Gold: {0}   |   Wood: {1}   |   Date: 01/01/1700", gold, wood);

		//Gold: 0   |   Wood:	 0   |   Date: 01/01/1700   

	}
}
