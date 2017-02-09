using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplaySettlementStats : MonoBehaviour {

	private bool _mouseOver = false;
	private GUIStyle style = new GUIStyle();

	// Use this for initialization
	void Start () {
		//style.font.material.SetColor("_Color", Color.black); //<<<------ this is giving a NullReferenceException....not sure why
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnGUI(){
		if (_mouseOver) {
			var totalDemand = 0;
			var energyDemanded = "";
			if (gameObject.transform.parent == null) 
			{
				totalDemand = gameObject.GetComponent<Settlement>().GetPerBuildingEnergyUnitsDemanded() * gameObject.GetComponent<Settlement>().transform.childCount;
				energyDemanded = gameObject.GetComponent<Settlement>().GetEnergyTypeDemanded();
			} else 
			{
				totalDemand = gameObject.transform.parent.GetComponent<Settlement>().GetPerBuildingEnergyUnitsDemanded() * gameObject.transform.parent.GetComponent<Settlement>().transform.childCount;
				energyDemanded = gameObject.transform.parent.GetComponent<Settlement>().GetEnergyTypeDemanded();
			}
			//Should eventually change this to GUI.Window or GUI.Box
			GUI.Label(new Rect(Input.mousePosition.x + 10, -(Input.mousePosition.y-Screen.height), 100, 100), string.Format("Energy Type Demanded: {0}",energyDemanded), style);
			GUI.Label(new Rect(Input.mousePosition.x + 10, -(Input.mousePosition.y-Screen.height) - 10, 100, 100), string.Format("Quantity Demanded: {0}",totalDemand), style);
		}
	}

	void OnMouseOver(){
		_mouseOver = true;
	}

	void OnMouseExit(){
		_mouseOver = false;
	}
}
