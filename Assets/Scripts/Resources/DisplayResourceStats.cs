using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayResourceStats : MonoBehaviour {

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
		style.fontSize = 10 - (int) (Camera.main.orthographicSize / 10);

		var totalDemand = gameObject.GetComponent<Resource>().GetTotalPotentialEnergy();
		var energyType = gameObject.GetComponent<Resource>().GetAssociateEnergyType();
		var point = Camera.main.WorldToScreenPoint (transform.position);

		GUI.Label(new Rect(point.x, -(point.y - Screen.height) - 15, 100, 100), string.Format("Total {0} potential: {1}",energyType,totalDemand), style);
		
	}

	void OnMouseOver(){
		_mouseOver = true;
		if (Input.GetMouseButtonDown(1)) {
		}
	}

	void OnMouseExit(){
		_mouseOver = false;
	}
}
