using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BottomBarScript : MonoBehaviour {

	public InputField woodInput;
	public InputField coalInput;

	int woodCost;
	int coalCost;

	public void onClick(){
	
		int wood;
		if (int.TryParse (woodInput.text, out wood)) {
			woodInput.textComponent.color = Color.green;
			PlayerPrefs.SetInt ("woodCost", wood);
			var lumbermills = GameObject.FindGameObjectsWithTag("Lumber Mill");
			foreach (GameObject mill in lumbermills) {
				mill.GetComponent<Structure> ().SetResourcePrice (wood);
			}
		} else {
			woodInput.text = "";
		}

		int coal;
		if (int.TryParse (coalInput.text, out coal)) {
			coalInput.textComponent.color = Color.green;
			PlayerPrefs.SetInt ("coalCost", coal);
			var mines = GameObject.FindGameObjectsWithTag("Coal Mine");
			foreach (GameObject mine in mines) {
				mine.GetComponent<Structure> ().SetResourcePrice (coal);
			}
		} else {
			coalInput.text = "";
		}
	}

	// Use this for initialization
	void Start () {
		PlayerPrefs.SetInt ("woodCost", 5);
		PlayerPrefs.SetInt ("coalCost", 15);
		woodInput.textComponent.color = Color.black;
		coalInput.textComponent.color = Color.black;
		woodInput.text = "5";
		coalInput.text = "15";
	}

	// Update is called once per frame
	void Update () {
		int currWood = PlayerPrefs.GetInt("woodCost");
		int currCoal = PlayerPrefs.GetInt("coalCost");

		int actualWood;
		int actualCoal;

		if (int.TryParse (woodInput.text, out actualWood)) {
			if (currWood != actualWood) {
				woodInput.textComponent.color = Color.gray;
			} else {
				woodInput.textComponent.color = Color.black;
			}
		}

		if (int.TryParse (coalInput.text, out actualCoal)) {
			if (currCoal != actualCoal) {
				coalInput.textComponent.color = Color.gray;
			} else {
				coalInput.textComponent.color = Color.black;
			}
		}
	}
}
