using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachResource : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		// get the structure
		var s = gameObject.GetComponent<Structure>();
		// if the structure is selected, otherwise don't do anything
		if (s.GetSelected()) {
			// iterate over all active game objects tagged as a "Resource"
			foreach (var obj in GameObject.FindGameObjectsWithTag("Resource")) {
				// this if else just determines whether or not we're on a parent object -> if we aren't then move to the parent
				if (obj.transform.parent == null) {
					// check for a selected resource, if the selected resource is the correct thing to associate with this structure (i.e. forest with lumber mill), 
					// and make sure this resource isn't already attached
					if (obj.GetComponent<Resource>().GetSelected() && 
						obj.GetComponent<Resource>().GetAssociateEnergyType() == s.GetAssociatedEnergyType() && 
						obj != s.GetResourceSource()) {
						// if it is then set this resoruce as that structure's resource source

						GameObject source = s.GetResourceSource ();
						if (source) {
							source.GetComponent<Resource> ().RemoveDestination (gameObject);
							foreach (Transform child in source.transform){
								child.GetComponent<SpriteRenderer> ().sprite = source.GetComponent<Resource>().unSelectedSprite;
							}
						}

						s.SetResourceSource(obj);
						// unselect the structure
						s.SetSelected(false);
						// unselect the resource
						obj.GetComponent<Resource>().SetSelected(false);
						//Debug.Log("attached");
						obj.GetComponent<Resource>().AddDestination(gameObject);
					}
				} else {
					if (obj.transform.parent.GetComponent<Resource>().GetSelected() && 
						obj.transform.parent.GetComponent<Resource>().GetAssociateEnergyType() == s.GetAssociatedEnergyType() && 
						obj.transform.parent.gameObject != s.GetResourceSource()) {
						s.SetResourceSource(obj.transform.parent.gameObject);
						s.SetSelected(false);
						obj.transform.parent.GetComponent<Resource>().SetSelected(false);

						//Debug.Log("attached");
					}
				}
			}
		}	
	}
}
