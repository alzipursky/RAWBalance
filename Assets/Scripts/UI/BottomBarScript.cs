using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BottomBarScript : MonoBehaviour {

	public InputField woodInput;
	public InputField coalInput;
	public Text competitorText;

	int woodCost;
	int coalCost;

	public void onClick(){
	
		int wood;
		if (int.TryParse (woodInput.text, out wood)) {
			if (wood > 0) {
				woodInput.textComponent.color = Color.black;
				PlayerPrefs.SetInt ("woodCost", wood);
				var lumbermills = GameObject.FindGameObjectsWithTag("Lumber Mill");
				foreach (GameObject mill in lumbermills) {
					mill.GetComponent<Structure> ().SetResourcePrice (wood);
				}
			} else {
				int w = PlayerPrefs.GetInt("woodCost");
				woodInput.text = w.ToString();
			}
		} else {
			int w = PlayerPrefs.GetInt("woodCost");
			woodInput.text = w.ToString();
		}

		int coal;
		if (int.TryParse (coalInput.text, out coal)) {
			if (coal > 0) {
				coalInput.textComponent.color = Color.black;
				PlayerPrefs.SetInt ("coalCost", coal);
				var mines = GameObject.FindGameObjectsWithTag("Coal Mine");
				foreach (GameObject mine in mines) {
					mine.GetComponent<Structure> ().SetResourcePrice (coal);
				}
			} else {
				int c = PlayerPrefs.GetInt("coalCost");
				coalInput.text = c.ToString();
			}

		} else {
			int c = PlayerPrefs.GetInt("coalCost");
			coalInput.text = c.ToString();
		}
	}

	// Use this for initialization
	void Start () {
		PlayerPrefs.SetInt ("woodCost", 5);
		PlayerPrefs.SetInt ("coalCost", 20);
		woodInput.text = "5";
		coalInput.text = "20";
		woodInput.textComponent.color = Color.black;
		coalInput.textComponent.color = Color.black;

		PlayerPrefs.SetInt ("competitorWoodCost", 5);
		PlayerPrefs.SetInt ("competitorCoalCost", 20);

		updateCompetitorText ();
	}

	void updateCompetitorText(){
		int cWc = PlayerPrefs.GetInt("competitorWoodCost");
		int cCc = PlayerPrefs.GetInt("competitorCoalCost");

		competitorText.text = string.Format ("Competitor - Wood Price: {0} - Coal Price: {1}", cWc, cCc);
	}

	float flag = 0f;

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
		updateCompetitorText ();

		if (flag >= 20f) {
			flag = 0f;

			float rnW = Random.Range(0.0f, 1.0f);
			float rnC = Random.Range(0.0f, 1.0f);

			int cWc = PlayerPrefs.GetInt("competitorWoodCost");
			int cCc = PlayerPrefs.GetInt("competitorCoalCost");

			if (rnW > 0.5f) { // Increase
				if (cWc > 12) {
					cWc -= 1;
				} else {
					cWc += 1;
				}
			} else { // Decrease
				if (cWc < 3) {
					cWc += 1;
				} else {
					cWc -= 1;
				}
			}

			if (rnC > 0.5f) {
				if (cCc > 28) {
					cCc -= 1;
				} else {
					cCc += 1;
				}
			} else { // Decrease
				if (cCc < 10) {
					cCc += 1;
				} else {
					cCc -= 1;
				}
			}

			PlayerPrefs.SetInt ("competitorWoodCost", cWc);
			PlayerPrefs.SetInt ("competitorCoalCost", cCc);

		} else {
			flag += Time.deltaTime;

		}




	}
}
