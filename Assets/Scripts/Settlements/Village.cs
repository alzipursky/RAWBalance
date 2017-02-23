﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Village : Settlement {

	private float elapsedTime = 0f;
	protected string name;
	private int demandIncrease = 5;

	// Use this for initialization
	void Start () {
		energyTypeDemanded = new List<string>();
		energyTypeDemanded.Add("wood");

		perBuildingEnergyUnitsDemanded = demandIncrease;
		totalResourceDemand = new Dictionary<string, int>();
		totalResourceDemand["wood"] = perBuildingEnergyUnitsDemanded * transform.childCount;

	}



	// Update is called once per frame
	void Update () {
		if (elapsedTime > 3f) {
			foreach (var energyType in energyTypeDemanded) {
				totalResourceDemand[energyType] += demandIncrease;
			}
			demandIncrease += 1;
			//would deplete the forest right here also
			elapsedTime = 0f;
		} else {
			elapsedTime += Time.deltaTime;
		}

	}
}
