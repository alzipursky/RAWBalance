using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settlement : MonoBehaviour {

	protected bool selected;

	protected string energyTypeDemanded;
	protected int perBuildingEnergyUnitsDemanded;
	protected Dictionary<string, int> totalResourceDemand;

	public Sprite selectedSprite;
	public Sprite unSelectedSprite;

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
		if (selected) {
			foreach (Transform child in transform){
				child.gameObject.GetComponent<SpriteRenderer>().sprite = selectedSprite;
			}
		} else {
			foreach (Transform child in transform){
				child.gameObject.GetComponent<SpriteRenderer>().sprite = unSelectedSprite;
			}
		}
	}

	public bool GetSelected()
	{
		return selected;
	}
		
	public int GetTotalResourceDemand(string resource)
	{
		return totalResourceDemand[resource];
	}

	public void SetTotalResourceDemand(string resource, int amount)
	{
		totalResourceDemand[resource] = amount;
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
