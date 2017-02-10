using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetBuildScript : MonoBehaviour {

	private int build;

	public Dropdown dropDown;

	void Start()
	{
		PlayerPrefs.SetString ("build", "None");
		dropDown.onValueChanged.AddListener(delegate {
			myDropdownValueChangedHandler(dropDown);
		});
	}

	void Destroy() {
		dropDown.onValueChanged.RemoveAllListeners();
	}

	private void myDropdownValueChangedHandler(Dropdown target) {
		//Debug.Log("selected: "+target.options[target.value].text);
		SetBuild (target.options[target.value].text);
	}

	public void SetDropdownIndex(int index) {
		dropDown.value = index;
	}

	void SetBuild (string name) {
		PlayerPrefs.SetString ("build", name);
	}

}
