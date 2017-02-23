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

			var wood = gameObject.GetComponent<Structure>().GetResourceSupply();

			var destinations = gameObject.GetComponent<Structure> ().GetResourceDestinations ();

			string cities = "";

			if (destinations.Count > 0) {
				shipping = true;

				int index = 0;
				if (destinations.Count <= 3) {
					foreach (GameObject dest in destinations) {
						if (index == 0) {
							cities += dest.GetComponent<Village>().name;
						} else {
							cities += ", ";

							if (index == destinations.Count - 1) {
								cities += "and ";
							}

							cities += dest.GetComponent<Village>().name;

						}

						index += 1;
					}
				} else {
					int over = destinations.Count - 3;
					foreach (GameObject dest in destinations) {
						if (index == 0) {
							cities += dest.GetComponent<Village>().name;
						} else {
							cities += ", ";
							cities += dest.GetComponent<Village>().name;

							if (index == 2) {
								break;
							}

						}

						index += 1;
					}
					cities += string.Format (", and {0} more", over);
				}


			}

			string choppingStatus = "";
			string shippingStatus = "";


			if (chopping) {
				choppingStatus = string.Format ("Production Status: Chopping Wood");
			} else {
				choppingStatus = string.Format ("Production Status: Paused");
			}

			if (shipping) {
				shippingStatus = string.Format ("Shipping Status: Connected to {0}", cities);
			} else {
				shippingStatus = string.Format ("Shipping Status: No Connections");
			}

			GUI.Label (new Rect (point.x, -(point.y - Screen.height) - 15, 100, 100), choppingStatus, style);
			GUI.Label (new Rect (point.x, -(point.y - Screen.height) - 15 + space, 100, 100), shippingStatus, style);
			GUI.Label(new Rect(point.x, -(point.y - Screen.height) - 15 + 2*space, 100, 100), string.Format("Total wood supply: {0}",wood), style);

		}
	}

	void OnMouseOver(){
		_mouseOver = true;
	}

	void OnMouseExit(){
		_mouseOver = false;
	}
}
