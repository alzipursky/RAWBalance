using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LumberMill : Structure {

	// Use this for initialization
	//test

	private float elapsedTime = 0f;

	void Awake()
	{
		price = 30000;
		fixedOperatingCosts = 50;
		associatedEnergyType = "wood";
		gameObject.tag = "Lumber Mill";
	}

	void Start () {
		//price = 30000;
		fixedOperatingCosts = 50;
		associatedEnergyType = "wood";
		gameObject.tag = "Lumber Mill";
	}

	// Update is called once per frame
	void Update () {
		if (built) {
			var gold = PlayerPrefs.GetInt("gold");
			//PlayerPrefs.SetInt("gold", gold - (int)((float)fixedOperatingCosts*Time.deltaTime));
		}

		if (resourceSource != null) {
			if (elapsedTime > 2f) {
				PlayerPrefs.SetInt("wood", PlayerPrefs.GetInt("wood") + 20);
				//would deplete the forest right here also
				elapsedTime = 0f;
			} else {
				elapsedTime += Time.deltaTime;
			}
		}

		if (resourceDestinations.Count != 0) {
			//would subtract from supply of wood and subtract from each settlement's demand here
			foreach (var dest in resourceDestinations) {
				var woodDemanded = dest.GetComponent<Settlement>().GetTotalResourceDemand("wood");
				var wood = PlayerPrefs.GetInt("wood");
				var gold = PlayerPrefs.GetInt("gold");
				if ((wood >= woodDemanded) && wood < 100) {
					dest.GetComponent<Settlement>().SetTotalResourceDemand("wood", 0);
					PlayerPrefs.SetInt("gold", gold + woodDemanded * 5);
				} else if ((wood >= woodDemanded) && wood >= 100) {
					dest.GetComponent<Settlement>().SetTotalResourceDemand("wood", 0);
					PlayerPrefs.SetInt("gold", gold + woodDemanded * 3);
				} else if (wood < woodDemanded) {
					//nothing yet
				}
			}
		}
	}
}
