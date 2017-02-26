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

	// Use this for initialization
	void Start () {


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
