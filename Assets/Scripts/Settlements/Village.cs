using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Village : Settlement {

	private float elapsedTime = 0f;
	protected string name;
	private int demandIncrease = 5;
	private float accelerationElapsedTime = 0f;

	// Use this for initialization
	void Start () {
		energyTypeDemanded = new List<string>();
		energyTypeDemanded.Add("wood");
		energyTypeDemanded.Add("coal");

		perBuildingEnergyUnitsDemanded = new Dictionary<string, int>();
		perBuildingEnergyUnitsDemanded["wood"] = demandIncrease;
		perBuildingEnergyUnitsDemanded["coal"] = demandIncrease;

		totalResourceDemand = new Dictionary<string, int>();
		totalResourceDemand["wood"] = perBuildingEnergyUnitsDemanded["wood"] * transform.childCount;
		totalResourceDemand["coal"] = perBuildingEnergyUnitsDemanded["coal"] * transform.childCount;

	}

	float growthflag = 0f;
	// Update is called once per frame
	void Update () {

		int competitorsGold = PlayerPrefs.GetInt ("competitorsGold");

		if (growthflag > 1f) {
			competitorsGold -= 1;

			if (buyingFromPlayer) {
				competitorsGold -= 18;
			} else {
				foreach (var energyType in energyTypeDemanded) {
					if (totalResourceDemand [energyType] > 1) {
						competitorsGold += 1;
					}
				}
			}



			PlayerPrefs.SetInt ("competitorsGold", competitorsGold);
			growthflag = 0;

		} else {
			growthflag += Time.deltaTime;

		}

		if (elapsedTime > 3f) {
			foreach (var energyType in energyTypeDemanded) {
				totalResourceDemand[energyType] += demandIncrease;
			}
			//would deplete the forest right here also
			elapsedTime = 0f;
		} else {
			elapsedTime += Time.deltaTime;
		}

		if (accelerationElapsedTime > 25f) {
			demandIncrease += 1;
			accelerationElapsedTime = 0f;
		} else {
			accelerationElapsedTime += Time.deltaTime;
		}

	}
}
