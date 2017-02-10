using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour {

	protected bool selected;

	protected string associatedEnergyType;
	protected int potentialEnergyPerUnit;
	protected int totalPotentialEnergy;

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

	public int GetTotalPotentialEnergy()
	{
		return totalPotentialEnergy;
	}

	public void SetSelected(bool b)
	{
		selected = b;
	}

	public bool GetSelected()
	{
		return selected;
	}

	void OnMouseOver()
	{
		if (Input.GetMouseButtonDown(1)) 
		{
			if (gameObject.transform.parent == null) {
				SetSelected(!GetSelected());
			} else {
				var par = gameObject.transform.parent.GetComponent<Resource>();
				par.SetSelected(!par.GetSelected());
			}
		}
	}
}
