using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Village : Settlement {

	private float elapsedTime = 0f;

	// Use this for initialization
	void Start () {
		energyTypeDemanded = "wood";
		perBuildingEnergyUnitsDemanded = 5;
		totalResourceDemand = new Dictionary<string, int>();
		totalResourceDemand[energyTypeDemanded] = perBuildingEnergyUnitsDemanded * transform.childCount;
	}
	
	// Update is called once per frame
	void Update () {
		if (elapsedTime > 3f) {
			totalResourceDemand[energyTypeDemanded] += 5;
			//would deplete the forest right here also
			elapsedTime = 0f;
		} else {
			elapsedTime += Time.deltaTime;
		}

	}
}
