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
		int currWood = PlayerPrefs.GetInt ("woodCost");
		int currCoal = PlayerPrefs.GetInt("coalCost");

		string status = " - ";

		string damage = "";

		if (currWood < cWc) {
			status += "Undercutting wood. ";
			damage += "A";
		} else if (currWood > cWc) {
			status += "Being undercut on wood. ";
			damage += "B";
		}

		if (currCoal < cCc) {
			status += "Under cutting coal.";
			damage += "A";
		} else if (currCoal > cCc) {
			status += "Being undercut on coal.";
			damage += "B";
		}

		if (status == " - ") {
			status += "Balanced prices.";
		}

		if (damage == "AA") {
			competitorText.color = new Color (33.0f / 255.0f, 128.0f / 255.0f, 92.0f / 255.0f, 1f);
		} else if (damage == "BA") {
			competitorText.color = Color.yellow;
		} else if (damage == "BB") {
			competitorText.color = Color.red;
		} else if (damage == "AB") {
			competitorText.color = Color.yellow;
		} else if (damage == "B") {
			competitorText.color = new Color (1f, 0.5f, 0f, 1f);
		} else if (damage == "A") {
			competitorText.color = new Color (33.0f / 255.0f, 128.0f / 255.0f, 62.0f / 255.0f, 1f);
		} else if (damage == "") {
			competitorText.color = Color.white;
		}

		competitorText.text = string.Format ("Competitor Wood: {0} & Coal: {1}{2}", cWc, cCc, status);
	}

	void updateWoodInputColors(bool gray){
		int cWc = PlayerPrefs.GetInt("competitorWoodCost");
		int currWood = PlayerPrefs.GetInt("woodCost");

		if (currWood < cWc) {
			woodInput.textComponent.color = new Color(33.0f/255.0f, 128.0f/255.0f, 92.0f/255.0f, 1f);
		} else if (currWood > cWc) {
			woodInput.textComponent.color = Color.red;
		} else if (currWood == cWc) {
			woodInput.textComponent.color = Color.black;
		}

		if (gray) {
			woodInput.textComponent.color = Color.gray;
		}

	}
		
	void updateCoalInputColors(bool gray){
		int cCc = PlayerPrefs.GetInt("competitorCoalCost");
		int currCoal = PlayerPrefs.GetInt("coalCost");

		if (currCoal < cCc) {
			coalInput.textComponent.color = new Color(33.0f/255.0f, 128.0f/255.0f, 92.0f/255.0f, 1f);
		} else if (currCoal > cCc) {
			coalInput.textComponent.color = Color.red;
		} else if (currCoal == cCc) {
			coalInput.textComponent.color = Color.black;
		}

		if (gray) {
			coalInput.textComponent.color = Color.gray;
		}

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
				updateWoodInputColors (true);
			} else {
				updateWoodInputColors (false);
			}

		}

		if (int.TryParse (coalInput.text, out actualCoal)) {
			if (currCoal != actualCoal) {
				updateCoalInputColors (true);
			} else {
				updateCoalInputColors (false);
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
