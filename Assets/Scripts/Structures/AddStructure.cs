using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class AddStructure : MonoBehaviour {

	public GameObject structure;
	private Vector3 target;

	private Vector3 guiLocation;
	private bool drawGui = false;
	private float timeSinceDraw = 0;

	private GUIStyle style = new GUIStyle();

	// Use this for initialization
	void Start () {
		//style.font.material.SetColor("_Color", Color.black); //<<<------ this is giving a NullReferenceException....not sure why
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0))
		{
			var gold = PlayerPrefs.GetInt("gold");
			var structurePrice = gameObject.GetComponent<Structure>().GetPrice();

			if (gold > structurePrice) 
			{
				target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
				target.z = 0;
				var newStructure = Instantiate(structure);
				newStructure.transform.position = target;
				newStructure.GetComponent<Structure>().SetBuilt(true);

				gold -= structurePrice;
				PlayerPrefs.SetInt("gold", gold);
			} else 
			{
				drawGui = true;
				timeSinceDraw = 0;
				guiLocation = Input.mousePosition;
				ErrorMessagePopup();
			}
		}
		if (drawGui) 
		{
			timeSinceDraw += Time.deltaTime;
			ErrorMessagePopup();
		}
	}

	void ErrorMessagePopup()
	{
		drawGui = timeSinceDraw < 3;
	}

	void OnGUI()
	{
		//Should eventually change this to GUI.Window or GUI.Box
		if (drawGui) 
		{
			GUI.Label(new Rect(guiLocation.x + 2, -(guiLocation.y - Screen.height), 100, 100), "You don't have enough gold to build that", style);
		}
	}
}
