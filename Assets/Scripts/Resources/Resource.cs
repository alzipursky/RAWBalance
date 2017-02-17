using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour {

	protected bool selected;

	protected string associatedEnergyType;
	protected int potentialEnergyPerUnit;
	protected int totalPotentialEnergy;


	public Sprite selectedSprite;
	public Sprite unSelectedSprite;

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

	void OnMouseOver()
	{
		if (Input.GetMouseButtonDown(1)) 
		{
			var objectTag = gameObject.tag;

			bool notAlreadySelected = true;

			foreach (var obj in GameObject.FindGameObjectsWithTag(objectTag)) {
				if (obj.GetComponent<Resource>().GetSelected()) {
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
				var par = gameObject.transform.parent.GetComponent<Resource>();
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
