using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settlement : MonoBehaviour {

	protected bool selected;

	protected List<string> energyTypeDemanded;
	//protected string energyTypeDemanded;
	//protected int perBuildingEnergyUnitsDemanded;
	protected Dictionary<string,int> perBuildingEnergyUnitsDemanded;
	protected Dictionary<string, int> totalResourceDemand;
	protected List<GameObject> resourceSources = new List<GameObject>();

	public Sprite selectedSprite;
	public Sprite unSelectedSprite;
	public Sprite hoverSprite;

	protected bool buyingFromPlayer = false;

	// Use this for initialization
	void Start () {


	}

	public void setBuyingFromPlayer(bool b){
		buyingFromPlayer = b;
	}

	public bool getBuyingFromPlayer(){
		return buyingFromPlayer;
	}

	// Update is called once per frame
	void Update () {
		
	}

	public void AddResourceSource(GameObject obj)
	{
		resourceSources.Add(obj);
	}

	public List<string> GetEnergyTypeDemanded()
	{
		return energyTypeDemanded;
	}

	public int GetPerBuildingEnergyUnitsDemanded(string resource)
	{
		return perBuildingEnergyUnitsDemanded[resource];
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

	public int GetResourceDemandAtPrice(string resource, int price)
	{
		if (resource == "wood") {
			switch (price) {
			case 1:
				return 100;
			case 2:
				return 90;
			case 3:
				return 70;
			case 4:
				return 80;
			case 5:
				return 40;
			case 6:
				return 30;
			case 7:
				return 20;
			case 8:
				return 15;
			case 9:
				return 10;
			case 10:
				return 9;
			case 11:
				return 8;
			case 12:
				return 7;
			case 13:
				return 6;
			case 14:
				return 5;
			case 15:
				return 4;
			case 16:
				return 3;
			case 17:
				return 2;
			case 18:
				return 1;
			default:
				return 0;
			}

		} else if (resource == "coal") {
			switch (price) {
			case 1:
				return 140;
			case 2:
				return 135;
			case 3:
				return 130;
			case 4:
				return 125;
			case 5:
				return 120;
			case 6:
				return 110;
			case 7:
				return 100;
			case 8:
				return 90;
			case 9:
				return 85;
			case 10:
				return 80;
			case 11:
				return 75;
			case 12:
				return 70;
			case 13:
				return 65;
			case 14:
				return 60;
			case 15:
				return 55;
			case 16:
				return 50;
			case 17:
				return 45;
			case 18:
				return 40;
			case 19:
				return 35;
			case 20:
				return 30;
			case 21:
				return 27;
			case 22:
				return 25;
			case 23:
				return 20;
			case 24:
				return 17;
			case 25:
				return 14;
			case 26:
				return 11;
			case 27:
				return 9;
			case 28:
				return 7;
			case 29:
				return 5;
			default:
				return 0;
			}
		} else {
			return 0;
		}
	}

	void OnMouseExit(){

		PlayerPrefs.SetString("canBuild", "true");

		if (gameObject.transform.parent == null) {

			foreach (GameObject source in resourceSources) {
				bool isSelected = source.GetComponent<Structure>().GetSelected();

				if (isSelected) {
					source.GetComponent<SpriteRenderer> ().sprite = source.GetComponent<Structure>().selectedSprite;

				} else {
					source.GetComponent<SpriteRenderer> ().sprite = source.GetComponent<Structure>().unSelectedSprite;

				}

			}

		} else {
			var par = gameObject.transform.parent.GetComponent<Settlement> ();
			foreach (GameObject source in par.resourceSources) {
				bool isSelected = source.GetComponent<Structure>().GetSelected();
				if (isSelected) {
					source.GetComponent<SpriteRenderer> ().sprite = source.GetComponent<Structure>().selectedSprite;

				} else {
					source.GetComponent<SpriteRenderer> ().sprite = source.GetComponent<Structure>().unSelectedSprite;

				}
			}
		}

	}

	void OnMouseOver()
	{

		PlayerPrefs.SetString("canBuild", "false");

		if (Input.GetMouseButtonDown (1)) {
			var objectTag = gameObject.tag;

			bool notAlreadySelected = true;

			foreach (var obj in GameObject.FindGameObjectsWithTag(objectTag)) {
				if (obj.GetComponent<Settlement> ().GetSelected ()) {
					notAlreadySelected = false;
					;
					break;
				}
			}

			if (gameObject.transform.parent == null) {
				if (!GetSelected ()) {
					if (notAlreadySelected) {
						SetSelected (!GetSelected ());
					}
				} else {
					SetSelected (!GetSelected ());
				}
			} else {
				var par = gameObject.transform.parent.GetComponent<Settlement> ();
				if (!par.GetSelected ()) {
					if (notAlreadySelected) {
						par.SetSelected (!par.GetSelected ());
					}
				} else {
					par.SetSelected (!par.GetSelected ());
				}
			}
		} else {

			if (gameObject.transform.parent == null) {
				foreach (GameObject source in resourceSources) {
					source.GetComponent<SpriteRenderer> ().sprite = source.GetComponent<Structure>().hoverSprite;
				}
					
			} else {
				var par = gameObject.transform.parent.GetComponent<Settlement> ();
				foreach (GameObject source in par.resourceSources) {
					source.GetComponent<SpriteRenderer> ().sprite = source.GetComponent<Structure>().hoverSprite;
				}
			}
				
		}
	}

    private int Wood_DemandatPrice(int wood_price)
    {
        switch(wood_price)
        {
            case 0:
                return 100;
            case 1:
                return 80;
            case 2:
                return 60;
            case 3:
                return 40;
            case 4:
                return 30;
            case 5:
                return 20;
            case 6:
                return 15;
            case 7:
                return 10;
            case 8:
                return 8;
            case 9:
                return 5;
        }

        if (wood_price >= 10)
        {
            return 0;
        }

        return 0;
    }
}
