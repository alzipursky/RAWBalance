using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachResource : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		var s = gameObject.GetComponent<Structure>();
		if (s.GetSelected()) {
			foreach (var obj in GameObject.FindGameObjectsWithTag("Resource")) {
				if (obj.transform.parent == null) {
					if (obj.GetComponent<Resource>().GetSelected() && obj.GetComponent<Resource>().GetAssociateEnergyType() == s.GetAssociatedEnergyType()) {
						s.SetResourceSource(obj);
						s.SetSelected(false);
						obj.GetComponent<Resource>().SetSelected(false);
					}
				} else {
					if (obj.transform.parent.GetComponent<Resource>().GetSelected() && obj.transform.parent.GetComponent<Resource>().GetAssociateEnergyType() == s.GetAssociatedEnergyType()) {
						s.SetResourceSource(obj.transform.parent.gameObject);
						s.SetSelected(false);
						obj.transform.parent.GetComponent<Resource>().SetSelected(false);
					}
				}
			}
		}	
	}
}
