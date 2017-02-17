using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplaySettlementStats : MonoBehaviour {

	private bool _mouseOver = false;
	GUIStyle style = new GUIStyle();

	// Use this for initialization
	void Start () {
		style.normal.textColor = Color.white;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnGUI(){
		var totalDemand = 0;
		var energyDemanded = "";
		if (gameObject.transform.parent == null) 
		{
			
			energyDemanded = gameObject.GetComponent<Settlement>().GetEnergyTypeDemanded();
			totalDemand = gameObject.GetComponent<Settlement>().GetTotalResourceDemand(energyDemanded);
		} else 
		{
			energyDemanded = gameObject.transform.parent.GetComponent<Settlement>().GetEnergyTypeDemanded();
			totalDemand = gameObject.transform.parent.GetComponent<Settlement>().GetTotalResourceDemand(energyDemanded);
		}
		//Should eventually change this to GUI.Window or GUI.Box
		GUI.Label(new Rect(transform.position.x + 50, transform.position.y - 100, 100, 100), string.Format("Energy Type Demanded: {0}",energyDemanded), style);
		GUI.Label(new Rect(transform.position.x + 50, transform.position.y - 120, 100, 100), string.Format("Quantity Demanded: {0}",totalDemand), style);
	}

	void OnMouseOver(){
		_mouseOver = true;
	}

	void OnMouseExit(){
		_mouseOver = false;
	}
}
