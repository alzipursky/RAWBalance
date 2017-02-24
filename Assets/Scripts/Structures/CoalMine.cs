using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoalMine : Structure {

	private float elapsedTime = 0f;

	// Use this for initialization
	void Awake () {
		price = 15000;
		fixedOperatingCosts = 150;
		associatedEnergyType = "coal";
		gameObject.tag = "Coal Mine";
		currentlyProducing = true;
	}

	void Start(){
		fixedOperatingCosts = 150;
		associatedEnergyType = "coal";
		gameObject.tag = "Coal Mine";
	}

	// Update is called once per frame
	void Update () {
		if (built) {
			var gold = PlayerPrefs.GetInt("gold");
			//PlayerPrefs.SetInt("gold", gold - (int)((float)fixedOperatingCosts*Time.deltaTime));
		}

		if (resourceSource != null) {
			int available = resourceSource.GetComponent<Resource> ().GetTotalPotentialEnergy ();

			if (elapsedTime > 2f && currentlyProducing && available > 0) {

				int consume = 20;

				if (available < consume) {
					consume = available;
				}

				var gold = PlayerPrefs.GetInt("gold");
				PlayerPrefs.SetInt("gold", gold - fixedOperatingCosts);

				resourceSupply += consume;
				resourceSource.GetComponent<Resource>().SetTotalPotentialEnergy(resourceSource.GetComponent<Resource>().GetTotalPotentialEnergy() - consume);
				//would deplete the forest right here also
				elapsedTime = 0f;
			} else {
				elapsedTime += Time.deltaTime;
			}
		}

		if (resourceDestinations.Count != 0) {
			//would subtract from supply of wood and subtract from each settlement's demand here
			foreach (var dest in resourceDestinations) {
				var woodDemanded = dest.GetComponent<Settlement>().GetTotalResourceDemand("coal");
				var gold = PlayerPrefs.GetInt("gold");
				if ((resourceSupply >= woodDemanded) && resourceSupply < 100) {
					dest.GetComponent<Settlement>().SetTotalResourceDemand("coal", 0);
					PlayerPrefs.SetInt("gold", gold + woodDemanded * 5);
					resourceSupply -= woodDemanded;
				} else if ((resourceSupply >= woodDemanded) && resourceSupply >= 100) {
					dest.GetComponent<Settlement>().SetTotalResourceDemand("coal", 0);
					PlayerPrefs.SetInt("gold", gold + woodDemanded * 5);
					resourceSupply -= woodDemanded;
				} else if (resourceSupply < woodDemanded) {
					dest.GetComponent<Settlement>().SetTotalResourceDemand("coal", woodDemanded - resourceSupply);
					PlayerPrefs.SetInt("gold", gold + resourceSupply * 5);
					resourceSupply = 0;
				}
			}
		}
	}
}
