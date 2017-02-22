using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildDisplayScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseOver(){
		var par = gameObject.transform.parent;
		if (par.GetComponent<Settlement> () != null) {
			par.GetComponent<DisplaySettlementStats> ()._mouseOver = true;
		} else if (par.GetComponent<Resource> () != null) {
			par.GetComponent<DisplayResourceStats> ()._mouseOver = true;
		}
	}

	void OnMouseExit(){
		var par = gameObject.transform.parent;
		if (par.GetComponent<Settlement> () != null) {
			par.GetComponent<DisplaySettlementStats> ()._mouseOver = false;
		} else if (par.GetComponent<Resource> () != null) {
			par.GetComponent<DisplayResourceStats> ()._mouseOver = false;
		}
	}
}
