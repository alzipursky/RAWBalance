using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplaySettlementStats : MonoBehaviour {

	private bool _mouseOver = false;

	GUIStyle style = new GUIStyle();

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		
	}

	void OnGUI(){
		style.normal.textColor = Color.white;
		style.fontSize = 12 - (int) (Camera.main.orthographicSize / 10);
		var space = 20 - (int) (Camera.main.orthographicSize / 8);
		var point = Camera.main.WorldToScreenPoint (transform.position);
		var name = gameObject.GetComponent<Village> ().name;

		var i = 0;
		GUI.Label(new Rect(point.x, -(point.y - Screen.height), 100, 100), string.Format("{0} Village",name), style);

		foreach (var energyDemanded in gameObject.GetComponent<Settlement>().GetEnergyTypeDemanded()) {
			var totalDemand = gameObject.GetComponent<Settlement>().GetTotalResourceDemand(energyDemanded);

			// going to need to fix this when they actually demand multiple resources
			GUI.Label(new Rect(point.x, -(point.y - Screen.height) + space + space*i, 100, 100), string.Format("Energy Type Demanded: {0}",energyDemanded), style);
			GUI.Label(new Rect(point.x, -(point.y - Screen.height) + 2*space + space*i, 100, 100), string.Format("Quantity Demanded: {0}",totalDemand), style);
			i += 1;
		}

	}


	void OnMouseOver(){
		_mouseOver = true;
	}

	void OnMouseExit(){
		_mouseOver = false;
	}
}
