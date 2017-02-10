using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settlement : MonoBehaviour {

	protected bool selected;

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
				var par = gameObject.transform.parent.GetComponent<Settlement>();
				par.SetSelected(!par.GetSelected());
			}
		}
	}
}
