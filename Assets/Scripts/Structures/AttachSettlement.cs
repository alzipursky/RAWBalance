using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachSettlement : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		var s = gameObject.GetComponent<Structure>();
		if (s.GetSelected()) {
			foreach (var obj in GameObject.FindGameObjectsWithTag("Settlement")) {
				if (obj.transform.parent == null) {
					if (obj.GetComponent<Settlement>().GetSelected() && !s.GetResourceDestinations().Contains(obj)) {
						s.AddResourceDestination(obj);	
						s.SetSelected(false);
						obj.GetComponent<Settlement>().SetSelected(false);
						//Debug.Log("Attached");
					}
				} else {
					if (obj.transform.parent.GetComponent<Settlement>().GetSelected() && !s.GetResourceDestinations().Contains(obj.transform.parent.gameObject)) {
						s.AddResourceDestination(obj.transform.parent.gameObject);
						s.SetSelected(false);
						obj.transform.parent.GetComponent<Settlement>().SetSelected(false);
						//Debug.Log("Attached");
					}
				}
			}
		}	
	}
}
