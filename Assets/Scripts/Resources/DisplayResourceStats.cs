using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayResourceStats : MonoBehaviour {

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
			var energyType = "";
			totalDemand = gameObject.GetComponent<Resource>().GetTotalPotentialEnergy();
			energyType = gameObject.GetComponent<Resource>().GetAssociateEnergyType();
			//Should eventually change this to GUI.Window or GUI.Box
			GUI.Label(new Rect(Input.mousePosition.x + 10, -(Input.mousePosition.y-Screen.height), 100, 100), string.Format("Total {0} potential: {1}",energyType,totalDemand), style);
		}
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
