using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Structure : MonoBehaviour {

	protected bool built;
	protected int price;
	protected float processingTime;
	protected int fixedOperatingCosts;

	// Use this for initialization
	void Start () {
		built = false;
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

	public bool GetBuilt()
	{
		return built;
	}

	public void SetBuilt(bool b)
	{
		built = b;
	}
}
