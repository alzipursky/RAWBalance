﻿using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class AddStructure : MonoBehaviour {

	public List<GameObject> structurePrefabs;
	public MonoBehaviour scriptP;
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

		var structureTag = PlayerPrefs.GetString("build");

		if (Input.GetMouseButtonDown(0) && (structureTag != "None") && !EventSystem.current.IsPointerOverGameObject())
		{
			var gold = PlayerPrefs.GetInt("gold");
			var structurePrice = 0;
			GameObject structurePrefab = null;
			foreach (var st in structurePrefabs) 
			{
				if(st.CompareTag(structureTag))
				{
					structurePrefab = st;
					var tmp = Instantiate(st);
					structurePrice = tmp.GetComponent<Structure>().GetPrice();
					Destroy(tmp);
					break;
				}
			}
			if (gold > structurePrice) 
			{
				target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
				target.z = 0;
				var newStructure = Instantiate(structurePrefab);
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
