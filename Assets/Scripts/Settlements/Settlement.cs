using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settlement : MonoBehaviour {

	protected string energyTypeDemanded;
	protected int perBuildingEnergyUnitsDemanded;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public string GetEnergyTypeDemanded()
	{
		return energyTypeDemanded;
	}

	public int GetPerBuildingEnergyUnitsDemanded()
	{
		return perBuildingEnergyUnitsDemanded;
	}
}
