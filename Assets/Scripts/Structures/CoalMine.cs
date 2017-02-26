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
				int shippingCost = (int)Vector3.Distance(transform.position, dest.transform.position);
				if ((resourceSupply >= coalDemanded) && (coalDemanded > 0) && (resourceSupply < 100)) {
					dest.GetComponent<Settlement>().SetTotalResourceDemand("coal", 0);
					PlayerPrefs.SetInt("gold", gold + coalDemanded * resourcePrice - shippingCost);
					resourceSupply -= coalDemanded;
				} else if ((resourceSupply >= coalDemanded) && (coalDemanded > 0) && (resourceSupply >= 100)) {
					dest.GetComponent<Settlement>().SetTotalResourceDemand("coal", 0);
					PlayerPrefs.SetInt("gold", gold + coalDemanded * resourcePrice - shippingCost);
					resourceSupply -= coalDemanded;
				} else if (resourceSupply < coalDemanded) {
					dest.GetComponent<Settlement>().SetTotalResourceDemand("coal", coalDemanded - resourceSupply);
					PlayerPrefs.SetInt("gold", gold + resourceSupply * resourcePrice - shippingCost);
					resourceSupply = 0;
				}
			}
		}
	}
}
