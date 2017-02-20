using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mountain : Resource
{

    // Use this for initialization
    void Start()
    {
        associatedEnergyType = "coal";
        potentialEnergyPerUnit = 60;

        if (gameObject.transform.parent == null)
        {
            totalPotentialEnergy = potentialEnergyPerUnit * gameObject.transform.childCount;
        }
        else
        {
            totalPotentialEnergy = potentialEnergyPerUnit * gameObject.transform.parent.transform.childCount;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}

