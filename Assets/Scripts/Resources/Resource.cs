using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour {

	protected string associatedEnergyType;
	protected int potentialEnergyPerUnit;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public string GetAssociateEnergyType()
	{
		return associatedEnergyType;
	}

	public int GetPotentialEnergyPerUnit()
	{
		return potentialEnergyPerUnit;
	}
}
