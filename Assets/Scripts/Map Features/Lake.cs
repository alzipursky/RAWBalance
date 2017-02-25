using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lake : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseExit()
	{
		PlayerPrefs.SetString("canBuild", "true");
	}

	void OnMouseOver()
	{
		PlayerPrefs.SetString("canBuild", "false");
	}
}
