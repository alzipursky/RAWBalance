using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Structure : MonoBehaviour {

	protected bool built;
	protected bool selected;
	protected bool currentlyProducing;

	protected int price;
	protected float processingTime;
	protected int fixedOperatingCosts;
	protected int resourceSupply;

	protected int resourcePrice;

	protected string associatedEnergyType;

	protected GameObject resourceSource;
	protected List<GameObject> resourceDestinations = new List<GameObject>();
	public Sprite selectedSprite;
	public Sprite unSelectedSprite;
	public Sprite hoverSprite;


	void Awake()
	{
		
	}

	// Use this for initialization
	void Start () {
		built = false;
		selected = false;
	}
	
	// Update is called once per frame
	void Update () {
	}

	public int GetResourcePrice()
	{
		return resourcePrice;
	}

	public void SetResourcePrice(int p)
	{
		resourcePrice = p;
	}

	public int GetPrice()
	{
		return price;
	}

	public void SetPrice(int p)
	{
		price = p;
	}

	public float GetProcessingTime()
	{
		return processingTime;
	}

	public int GetFixedOperatingCosts()
	{
		return fixedOperatingCosts;
	}

	public int GetResourceSupply(){
		return resourceSupply;
	}

	public void SetResourceSupply(int supply){
		resourceSupply = supply;
	}

	public string GetAssociatedEnergyType()
	{
		return associatedEnergyType;
	}

	public bool GetBuilt()
	{
		return built;
	}

	public void SetBuilt(bool b)
	{
		built = b;
	}

	public void SetSelected(bool b)
	{
		selected = b;
		if (selected) {
			gameObject.GetComponent<SpriteRenderer>().sprite = selectedSprite;
		} else {
			gameObject.GetComponent<SpriteRenderer>().sprite = unSelectedSprite;
		}
	}

	public bool GetSelected()
	{
		return selected;
	}

	public bool GetCurrentlyProducing()
	{
		return currentlyProducing;
	}

	public void SetCurrentlyProducing(bool b)
	{
		currentlyProducing = b;
	}

	public GameObject GetResourceSource()
	{
		return resourceSource;
	}

	public void SetResourceSource(GameObject obj)
	{
		resourceSource = obj;
	}

	public List<GameObject> GetResourceDestinations()
	{
		return resourceDestinations;
	}

	public void AddResourceDestination(GameObject obj)
	{
		resourceDestinations.Add(obj);
	}

	void OnMouseExit() {

		PlayerPrefs.SetString("canBuild", "true");

		if (gameObject.transform.parent == null) {
			foreach (GameObject destination in resourceDestinations) {
				bool isSelected = destination.GetComponent<Settlement> ().GetSelected();

				foreach (Transform child in destination.transform){
					if (isSelected) {
						child.GetComponent<SpriteRenderer> ().sprite = destination.GetComponent<Settlement>().selectedSprite;

					} else {
						child.GetComponent<SpriteRenderer> ().sprite = destination.GetComponent<Settlement>().unSelectedSprite;
					}
				}
			}

		} else {
			var par = gameObject.transform.parent.GetComponent<Structure> ();

			foreach (GameObject destination in par.resourceDestinations) {
				bool isSelected = destination.GetComponent<Resource> ().GetSelected();

				foreach (Transform child in destination.transform){
					if (isSelected) {
						child.GetComponent<SpriteRenderer> ().sprite = destination.GetComponent<Settlement>().selectedSprite;

					} else {
						child.GetComponent<SpriteRenderer> ().sprite = destination.GetComponent<Settlement>().unSelectedSprite;
					}
				}
			}
		}

		if (resourceSource) {
			bool isSelected = resourceSource.GetComponent<Resource> ().GetSelected();

			foreach (Transform child in resourceSource.transform){
				if (isSelected) {
					child.GetComponent<SpriteRenderer> ().sprite = resourceSource.GetComponent<Resource>().selectedSprite;

				} else {
					child.GetComponent<SpriteRenderer> ().sprite = resourceSource.GetComponent<Resource>().unSelectedSprite;
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
				if (obj.GetComponent<Structure> ().GetSelected ()) {
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
				var par = gameObject.transform.parent.GetComponent<Structure> ();
				if (!par.GetSelected ()) {
					if (notAlreadySelected) {
						par.SetSelected (!par.GetSelected ());
					}
				} else {
					par.SetSelected (!par.GetSelected ());
				}
			}
		} else if (Input.GetMouseButtonDown(0)){
			if (resourceSource != null) {
				if (gameObject.transform.parent == null) {
					SetCurrentlyProducing(!GetCurrentlyProducing());
				} else {
					var par = gameObject.transform.parent.GetComponent<Structure> ();
					par.SetCurrentlyProducing(!par.GetCurrentlyProducing());
				}
			}
		} else {
			if (gameObject.transform.parent == null) {
				foreach (GameObject destination in resourceDestinations) {
					foreach (Transform child in destination.transform){
						child.GetComponent<SpriteRenderer> ().sprite = destination.GetComponent<Settlement>().hoverSprite;
					}
				}

			} else {
				var par = gameObject.transform.parent.GetComponent<Structure> ();
				foreach (GameObject destination in par.resourceDestinations) {
					foreach (Transform child in destination.transform){
						child.GetComponent<SpriteRenderer> ().sprite = destination.GetComponent<Settlement>().hoverSprite;
					}
				}
			}

			if (resourceSource) {
				foreach (Transform child in resourceSource.transform){
					child.GetComponent<SpriteRenderer> ().sprite = resourceSource.GetComponent<Resource>().hoverSprite;
				}
			}
		}
	}
}
