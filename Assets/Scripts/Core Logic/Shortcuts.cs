using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shortcuts : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown(KeyCode.Escape)){
			Deselect();
			PlayerPrefs.SetString ("build", "None");
		}

		if (Input.GetKeyDown(KeyCode.Z)) {
			PlayerPrefs.SetString("build", "Lumber Mill");
		}
			
		if (Input.GetKeyDown(KeyCode.X)) {
			PlayerPrefs.SetString("build", "Coal Mine");
		}

		if (Input.GetKeyDown(KeyCode.C)){
			PlayerPrefs.SetString("build", "Forest");
		}

	}

	private void Deselect()
	{
		foreach (var obj in GameObject.FindObjectsOfType<GameObject>()) {
			if (obj.CompareTag("Resource")) {
				obj.GetComponent<Resource>().SetSelected(false);
			}

			if (obj.CompareTag("Settlement")) {
				obj.GetComponent<Settlement>().SetSelected(false);
			}

			if (obj.CompareTag("Lumber Mill")) {
				obj.GetComponent<LumberMill>().SetSelected(false);
			}

			if (obj.CompareTag("Coal Mine")) {
				obj.GetComponent<CoalMine>().SetSelected(false);
			}
		}
	}
}
