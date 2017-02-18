using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settlement : MonoBehaviour {

	protected bool selected;

	protected List<string> energyTypeDemanded;
	//protected string energyTypeDemanded;
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

	public List<string> GetEnergyTypeDemanded()
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
			var objectTag = gameObject.tag;

			bool notAlreadySelected = true;

			foreach (var obj in GameObject.FindGameObjectsWithTag(objectTag)) {
				if (obj.GetComponent<Settlement>().GetSelected()) {
					notAlreadySelected = false;;
					break;
				}
			}

			if (gameObject.transform.parent == null) {
				if (!GetSelected()) {
					if (notAlreadySelected) {
						SetSelected(!GetSelected());
					}
				} else {
					SetSelected(!GetSelected());
				}
			} else {
				var par = gameObject.transform.parent.GetComponent<Settlement>();
				if (!par.GetSelected()) {
					if (notAlreadySelected) {
						par.SetSelected(!par.GetSelected());
					}
				} else {
					par.SetSelected(!par.GetSelected());
				}
			}
		}
	}
}
