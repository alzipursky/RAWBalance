using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetBuildScript : MonoBehaviour {

	public Dropdown dropDown;

	void Start()
	{
		PlayerPrefs.SetString ("build", "None");
		dropDown.onValueChanged.AddListener(delegate {
			myDropdownValueChangedHandler(dropDown);
		});
	}

	void Update(){
		string build = PlayerPrefs.GetString ("build");
		if (build == "None") {
			dropDown.value = 0;
		} else if (build == "Lumber Mill") {
			dropDown.value = 1;
		} else if (build == "Coal Mine") {
			dropDown.value = 2;
		} else if (build == "Forest") {
			dropDown.value = 3;
		}
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
