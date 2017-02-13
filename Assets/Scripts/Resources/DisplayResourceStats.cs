using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayResourceStats : MonoBehaviour {

	private bool _mouseOver = false;
	GUIStyle style = new GUIStyle();

	// Use this for initialization
	void Start () {
		style.normal.textColor = Color.white;

		// For background color, doesn't really look good

//		Texture2D tex = Texture2D.blackTexture;
//		var fillColor = new Color(0.0f, 0.0f, 0.0f);
//		var fillColorArray =  tex.GetPixels();
//
//		for(var i = 0; i < fillColorArray.Length; ++i)
//		{
//			fillColorArray[i] = fillColor;
//		}
//
//		tex.SetPixels( fillColorArray );
//		tex.Apply();
//
//		style.normal.background = tex;
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
