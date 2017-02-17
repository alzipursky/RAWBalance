using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Structure : MonoBehaviour {

	protected bool built;
	protected bool selected;

	protected int price;
	protected float processingTime;
	protected int fixedOperatingCosts;

	protected string associatedEnergyType;

	protected GameObject resourceSource;
	protected List<GameObject> resourceDestinations = new List<GameObject>();
	public Sprite selectedSprite;
	public Sprite unSelectedSprite;


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

	public int GetPrice()
	{
		return price;
	}

	public float GetProcessingTime()
	{
		return processingTime;
	}

	public int GetFixedOperatingCosts()
	{
		return fixedOperatingCosts;
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

	public GameObject GetResourceSource()
	{
		return resourceSource;
	}

	public void SetResourceSource(GameObject obj)
	{
		resourceSource = obj;
	}

	public void AddResourceDestination(GameObject obj)
	{
		resourceDestinations.Add(obj);
	}

	void OnMouseOver()
	{
		if (Input.GetMouseButtonDown(1)) 
		{
			if (gameObject.transform.parent == null) {
				SetSelected(!GetSelected());
			} else {
				var par = gameObject.transform.parent.GetComponent<Structure>();
				par.SetSelected(!par.GetSelected());
			}
		}
	}
}
