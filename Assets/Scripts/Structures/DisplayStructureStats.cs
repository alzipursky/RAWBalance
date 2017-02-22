using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayStructureStats : MonoBehaviour {

	protected bool _mouseOver = false;
	GUIStyle style = new GUIStyle();
	private int display;

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {

	}

	void OnGUI(){
		display = PlayerPrefs.GetInt("display", display);

		if (display > 0 || _mouseOver) {
	
			style.normal.textColor = Color.white;
			style.fontSize = 10 - (int) (Camera.main.orthographicSize / 10);
	
			var point = Camera.main.WorldToScreenPoint (transform.position);
			var space = 20 - (int) (Camera.main.orthographicSize / 8);

			bool chopping = false;
			bool shipping = false;

			if (gameObject.GetComponent<Structure> ().GetResourceSource() && gameObject.GetComponent<Structure>().GetCurrentlyProducing()) {
				chopping = true;
			}

			if (gameObject.GetComponent<Structure> ().GetResourceDestinations().Count > 0) {
				shipping = true;
			}

			var wood = gameObject.GetComponent<Structure>().GetResourceSupply();

			if (chopping && !shipping) {
				GUI.Label (new Rect (point.x, -(point.y - Screen.height) - 15, 100, 100), string.Format ("Chopping Wood"), style);
				GUI.Label(new Rect(point.x, -(point.y - Screen.height) - 15 + space, 100, 100), string.Format("Total wood supply: {0}",wood), style);

			} else if (chopping && shipping) {
				GUI.Label (new Rect (point.x, -(point.y - Screen.height) - 15, 100, 100), string.Format ("Producing and Selling Wood"), style);
				GUI.Label(new Rect(point.x, -(point.y - Screen.height) - 15 + space, 100, 100), string.Format("Total wood supply: {0}",wood), style);

			} else if (shipping && !chopping) {
				GUI.Label (new Rect (point.x, -(point.y - Screen.height) - 15, 100, 100), string.Format ("Connected to Village"), style);
				GUI.Label(new Rect(point.x, -(point.y - Screen.height) - 15 + space, 100, 100), string.Format("Total wood supply: {0}",wood), style);

			} else if (!shipping && !chopping) {
				GUI.Label (new Rect (point.x, -(point.y - Screen.height) - 15, 100, 100), string.Format ("Inactive"), style);
				GUI.Label(new Rect(point.x, -(point.y - Screen.height) - 15 + space, 100, 100), string.Format("Total wood supply: {0}",wood), style);
			}
		}
	}

	void OnMouseOver(){
		_mouseOver = true;
	}

	void OnMouseExit(){
		_mouseOver = false;
	}
}
