﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mountain : Resource
{
	private float elapsedTime = 0f;

	private int originalSupply;
	private Vector3 originalScale;

    // Use this for initialization
    void Start()
    {
        associatedEnergyType = "coal";
        potentialEnergyPerUnit = 2250;

        if (gameObject.transform.parent == null)
        {
            totalPotentialEnergy = potentialEnergyPerUnit * gameObject.transform.childCount;
        }
        else
        {
            totalPotentialEnergy = potentialEnergyPerUnit * gameObject.transform.parent.transform.childCount;
        }

		originalSupply = totalPotentialEnergy;
		originalScale = gameObject.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
		if (elapsedTime > 300f) {
			elapsedTime = 0f;
			totalPotentialEnergy += 1;
		} else {
			elapsedTime += Time.deltaTime;
		}
		//make the forest look depleted
		gameObject.transform.localScale = originalScale * ((totalPotentialEnergy / (float)(originalSupply*2)) + 0.5f);
    }
}

