using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayStructureStats : MonoBehaviour {

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

//		var totalDemand = gameObject.GetComponent<Resource>().GetTotalPotentialEnergy();
//		var energyType = gameObject.GetComponent<Resource>().GetAssociateEnergyType();
		var point = Camera.main.WorldToScreenPoint (transform.position);

//		GUI.Label(new Rect(point.x, -(point.y - Screen.height) - 15, 100, 100), string.Format("Total {0} potential: {1}",energyType,totalDemand), style);

		bool chopping = false;
		bool shipping = false;

		if (gameObject.GetComponent<Structure> ().GetResourceSource()) {
			chopping = true;
		}

		if (gameObject.GetComponent<Structure> ().GetResourceDestinations().Count > 0) {
			shipping = true;
		}
			
		if (chopping && !shipping) {
			GUI.Label (new Rect (point.x, -(point.y - Screen.height) - 15, 100, 100), string.Format ("Chopping Wood"), style);

		} else if (chopping && shipping) {
			GUI.Label (new Rect (point.x, -(point.y - Screen.height) - 15, 100, 100), string.Format ("Producing and Selling Wood"), style);

		} else if (shipping && !chopping) {
			GUI.Label (new Rect (point.x, -(point.y - Screen.height) - 15, 100, 100), string.Format ("Connected to Village"), style);

		} else if (!shipping && !chopping) {
			GUI.Label (new Rect (point.x, -(point.y - Screen.height) - 15, 100, 100), string.Format ("Inactive"), style);

		}
	}

	void OnMouseOver(){
		_mouseOver = true;
	}

	void OnMouseExit(){
		_mouseOver = false;
	}
}
