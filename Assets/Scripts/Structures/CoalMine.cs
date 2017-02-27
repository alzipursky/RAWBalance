	using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoalMine : Structure {

	private float elapsedTime = 0f;

	// Use this for initialization
	void Awake () {
		price = 15000;
		fixedOperatingCosts = 135;
		associatedEnergyType = "coal";
		gameObject.tag = "Coal Mine";
		currentlyProducing = true;
		resourcePrice = 20;
	}

	void Start(){
		fixedOperatingCosts = 135;
		associatedEnergyType = "coal";
		gameObject.tag = "Coal Mine";
		resourcePrice = 20;
	}

	// Update is called once per frame
	void Update () {
		if (resourceSource != null) {
			int available = resourceSource.GetComponent<Resource> ().GetTotalPotentialEnergy ();

			if (elapsedTime > 4f && currentlyProducing && available > 0) {

				int consume = 18;

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
				
				var coalDemanded = dest.GetComponent<Settlement>().GetTotalResourceDemand("coal");
				var gold = PlayerPrefs.GetInt("gold");

				var coalDemandedAtPrice = dest.GetComponent<Settlement>().GetResourceDemandAtPrice("wood", resourcePrice);
				var coalToSell = Mathf.Min(coalDemanded, coalDemandedAtPrice);

				int shippingCost = (int)Vector3.Distance(transform.position, dest.transform.position);


				int competitorResourceCost = PlayerPrefs.GetInt("competitorCoalCost");
				var competitorDemandedAtPrice = dest.GetComponent<Settlement>().GetResourceDemandAtPrice("coal", competitorResourceCost);

				if (competitorResourceCost < resourcePrice) {
					coalDemanded -= competitorDemandedAtPrice;
					if (coalDemanded < 0) {
						dest.GetComponent<Settlement>().SetTotalResourceDemand("coal", 0);

					} else {
						dest.GetComponent<Settlement>().SetTotalResourceDemand("coal", coalDemanded);

					}

				} else {
					if ((resourceSupply >= coalToSell) && (coalToSell > 0)) {
						dest.GetComponent<Settlement>().SetTotalResourceDemand("coal", 0);
						PlayerPrefs.SetInt("gold", gold + coalToSell * resourcePrice - shippingCost);
						resourceSupply -= coalDemanded;

					} else if (resourceSupply < coalToSell) {
						dest.GetComponent<Settlement>().SetTotalResourceDemand("coal", coalDemanded - resourceSupply);
						PlayerPrefs.SetInt("gold", gold + resourceSupply * resourcePrice - shippingCost);
						resourceSupply = 0;
					} else if (coalToSell == 0 && coalDemanded > 0) {
						coalDemanded -= competitorDemandedAtPrice;
						if (coalDemanded < 0) {
							dest.GetComponent<Settlement>().SetTotalResourceDemand("coal", 0);

						} else {
							dest.GetComponent<Settlement>().SetTotalResourceDemand("coal", coalDemanded);

						}
					}
				}
			}
		}
	}
}
