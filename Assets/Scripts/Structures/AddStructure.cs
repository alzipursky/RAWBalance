using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class AddStructure : MonoBehaviour {

	public List<GameObject> structurePrefabs;
	public Texture lumberMillTexture;
	public Texture coalMineTexture;
	public Texture treeTexture;
	public GameObject treePrefab;
	private Vector3 target;

	private Vector3 guiLocation;
	private bool drawGui = false;
	private bool drawMouseObj = false;
	private bool drawingResource = false;
	private float timeSinceDraw = 0;
	private int operatingCost;
	private int distanceFactor;

	GUIStyle style = new GUIStyle();

	private Texture textureToDraw;

	// Use this for initialization
	void Start () {
		//style.font.material.SetColor("_Color", Color.black); //<<<------ this is giving a NullReferenceException....not sure why
	}
	
	// Update is called once per frame
	void Update () {

		var structureTag = PlayerPrefs.GetString("build");

		if (structureTag == "None") {
			drawMouseObj = false;
			drawingResource = false;
		}

		if (structureTag == "Forest") {
			structureTag = "Resource";
		}

		if (structureTag != "None" && !EventSystem.current.IsPointerOverGameObject()) {
			foreach (var st in structurePrefabs) {
				if (st.CompareTag(structureTag)) {
					drawMouseObj = true;
					guiLocation = Input.mousePosition;
					guiLocation.z = 0;
					var tmp = Instantiate(st);
					if (tmp.GetComponent<Structure>()) {
						operatingCost = tmp.GetComponent<Structure>().GetFixedOperatingCosts();
					}
					Destroy(tmp);
					if (structureTag == "Lumber Mill") {
						textureToDraw = lumberMillTexture;
						int minDist = 9999999;
						foreach (var obj in GameObject.FindGameObjectsWithTag("Resource")) {
							if (obj.GetComponent<Forest>()) {
								int dist = (int)Vector3.Distance(Camera.main.ScreenToWorldPoint(guiLocation), obj.transform.position);
								if (dist < minDist) {
									minDist = dist;
								}
							}
						}
						distanceFactor = minDist;
						drawingResource = false;
					} else if (structureTag == "Coal Mine") {
						textureToDraw = coalMineTexture;
						int minDist = 9999999;
						foreach (var obj in GameObject.FindGameObjectsWithTag("Resource")) {
							if (obj.GetComponent<Mountain>()) {
								int dist = (int)Vector3.Distance(Camera.main.ScreenToWorldPoint(guiLocation), obj.transform.position);
								if (dist < minDist) {
									minDist = dist;
								}
							}
						}
						distanceFactor = minDist;
						drawingResource = false;
					} else {
						textureToDraw = treeTexture;
						drawingResource = true;
					}
					break;
				}
			}
		}

		if (Input.GetMouseButtonDown(0) && (structureTag != "None") && !EventSystem.current.IsPointerOverGameObject() && PlayerPrefs.GetString("canBuild")=="true")
		{
			drawMouseObj = false;
			drawingResource = false;
			var gold = PlayerPrefs.GetInt("gold");
			var structurePrice = 0;
			GameObject structurePrefab = null;
			foreach (var st in structurePrefabs) 
			{
				if(st.CompareTag(structureTag))
				{
					structurePrefab = st;
					var tmp = Instantiate(st);
					if (tmp.GetComponent<Structure>()) {
						structurePrice = tmp.GetComponent<Structure>().GetPrice();
					} else {
						structurePrice = tmp.GetComponent<Forest>().GetReplantPrice();
					}
					Destroy(tmp);
					break;
				}
			}
			if (gold > structurePrice) 
			{
				target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
				target.z = 0;
				var newStructure = Instantiate(structurePrefab);
				if (newStructure.GetComponent<Structure>()) {
					newStructure.transform.position = target;
					newStructure.GetComponent<Structure>().SetBuilt(true);
				} else {
					newStructure.transform.position = target;

					for (float j = -1f; j < 3f; j+= (2f / 3)) 
					{
						for (float i = 0f; i < 3f; i += (2f / 3)) {
							Vector3 targ = new Vector3(target.x + i, target.y + j);
							targ.z = 0;
							var tree = Instantiate(treePrefab);
							tree.transform.position = targ;
							tree.transform.parent = newStructure.transform;
							tree.transform.localScale = new Vector3(4f, 4f);
						}
					}
				}
				gold -= structurePrice;
				PlayerPrefs.SetInt("gold", gold);
				PlayerPrefs.SetString ("build", "None");
			} else 
			{
				drawGui = true;
				timeSinceDraw = 0;
				guiLocation = Input.mousePosition;
				guiLocation.z = 0;
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
		style.normal.textColor = Color.white;
		style.fontSize = 10 - (int) (Camera.main.orthographicSize / 10);
		//Should eventually change this to GUI.Window or GUI.Box
		if (drawGui) 
		{
			GUI.Label(new Rect(guiLocation.x + 2, -(guiLocation.y - Screen.height), 100, 100), "You don't have enough gold to build that", style);
		}

		if (drawMouseObj && PlayerPrefs.GetString("canBuild")=="true" && !drawingResource) 
		{
			GUI.DrawTexture(new Rect(guiLocation.x-9, -(guiLocation.y - Screen.height+22), 40, 40),textureToDraw);
			GUI.Label(new Rect(guiLocation.x-2, -(guiLocation.y - Screen.height+22), 40, 40),string.Format("Minimum Production Cost: {0}",operatingCost+distanceFactor),style);
		}

		if (drawMouseObj && PlayerPrefs.GetString("canBuild")=="true" && drawingResource) 
		{
			GUI.DrawTexture(new Rect(guiLocation.x-9, -(guiLocation.y - Screen.height+22), 40, 40),textureToDraw);
		}

	}
}
