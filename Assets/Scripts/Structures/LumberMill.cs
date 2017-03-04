using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LumberMill : Structure {

	// Use this for initialization
	//test

	private float elapsedTime = 0f;

	void Awake()
	{
		price = 7500;
		fixedOperatingCosts = 55;
		associatedEnergyType = "wood";
		gameObject.tag = "Lumber Mill";
		currentlyProducing = true;
		resourcePrice = 5;
	}

	void Start () {
		//price = 30000;
		fixedOperatingCosts = 75;
		associatedEnergyType = "wood";
		gameObject.tag = "Lumber Mill";
		resourcePrice = 5;
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
				
				var woodDemanded = dest.GetComponent<Settlement>().GetTotalResourceDemand("wood");
				var gold = PlayerPrefs.GetInt("gold");

				var woodDemandedAtPrice = dest.GetComponent<Settlement>().GetResourceDemandAtPrice("wood", resourcePrice);
				var woodToSell = Mathf.Min(woodDemanded, woodDemandedAtPrice);

				int shippingCost = (int)Vector3.Distance(transform.position, dest.transform.position);

				int competitorResourceCost = PlayerPrefs.GetInt("competitorWoodCost");
				var competitorDemandedAtPrice = dest.GetComponent<Settlement>().GetResourceDemandAtPrice("wood", competitorResourceCost);

				if (competitorResourceCost < resourcePrice) {
					woodDemanded -= competitorDemandedAtPrice;
					if (woodDemanded < 0) {
						dest.GetComponent<Settlement>().SetTotalResourceDemand("wood", 0);

					} else {
						dest.GetComponent<Settlement>().SetTotalResourceDemand("wood", woodDemanded);

					}

				} else {
					if ((resourceSupply >= woodToSell) && (woodToSell > 0)) {
						dest.GetComponent<Settlement> ().SetTotalResourceDemand ("wood", 0);
						PlayerPrefs.SetInt ("gold", gold + woodToSell * resourcePrice - shippingCost);
						resourceSupply -= woodToSell;

					} else if (resourceSupply < woodToSell && (resourceSupply > 0)) {
						dest.GetComponent<Settlement> ().SetTotalResourceDemand ("wood", woodDemanded - resourceSupply);
						PlayerPrefs.SetInt ("gold", gold + resourceSupply * resourcePrice - shippingCost);
						resourceSupply = 0;
					} else if (woodToSell == 0 && woodDemanded > 0) {
						woodDemanded -= competitorDemandedAtPrice;
						if (woodDemanded < 0) {
							dest.GetComponent<Settlement>().SetTotalResourceDemand("wood", 0);

						} else {
							dest.GetComponent<Settlement>().SetTotalResourceDemand("wood", woodDemanded);

						}
					}
				}


			}
		}
	}
}
