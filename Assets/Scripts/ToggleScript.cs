using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ToggleScript : MonoBehaviour {

	public Toggle[] toggles;
	private bool[] body;
	private bool[] muscle;
	private bool[] lip;
	private bool[] head;
	private bool[] ears;
	private bool[] tail;
	private bool[] tongue;
	private bool[] paw;
	private bool[] eyes;

	// Use this for initialization
	void Start () {
		// Add toggles from UI to array
		toggles = new Toggle[9];
		toggles [0] = GameObject.Find ("bodyToggle").GetComponent<Toggle> ();
		toggles [1] = GameObject.Find ("muscleToggle").GetComponent<Toggle> ();
		toggles [2] = GameObject.Find ("lipToggle").GetComponent<Toggle> ();
		toggles [3] = GameObject.Find ("headToggle").GetComponent<Toggle> ();
		toggles [4] = GameObject.Find ("earToggle").GetComponent<Toggle> ();
		toggles [5] = GameObject.Find ("tailToggle").GetComponent<Toggle> ();
		toggles [6] = GameObject.Find ("tongueToggle").GetComponent<Toggle> ();
		toggles [7] = GameObject.Find ("pawToggle").GetComponent<Toggle> ();
		toggles [8] = GameObject.Find ("eyesToggle").GetComponent<Toggle> ();

		// Grab booleans for whether or not a button has been selected for each body part
		body = GameObject.Find ("Canvas").GetComponent<AttributeHandler> ().bodySelected;
		muscle = GameObject.Find ("Canvas").GetComponent<AttributeHandler> ().muscleSelected;
		lip = GameObject.Find ("Canvas").GetComponent<AttributeHandler> ().lipsSelected;
		head = GameObject.Find ("Canvas").GetComponent<AttributeHandler> ().headSelected;
		ears = GameObject.Find ("Canvas").GetComponent<AttributeHandler> ().earsSelected;
		tail = GameObject.Find ("Canvas").GetComponent<AttributeHandler> ().tailSelected;
		tongue = GameObject.Find ("Canvas").GetComponent<AttributeHandler> ().tongueSelected;
		paw = GameObject.Find ("Canvas").GetComponent<AttributeHandler> ().pawSelected;
		eyes = GameObject.Find ("Canvas").GetComponent<AttributeHandler> ().eyesSelected;
	}


	// Update is called once per frame
	void Update () {
		grabValues ();
		checkIfSelected (toggles[0], body);
		checkIfSelected (toggles[1], muscle);
		checkIfSelected (toggles[2], lip);
		checkIfSelected (toggles[3], head);
		checkIfSelected (toggles[4], ears);
		checkIfSelected (toggles[5], tail);
		checkIfSelected (toggles[6], tongue);
		checkIfSelected (toggles[7], paw);
		checkIfSelected (toggles[8], eyes);

	}

	void grabValues() {
		// Grab booleans for whether or not a button has been selected for each body part
		body = GameObject.Find ("Canvas").GetComponent<AttributeHandler> ().bodySelected;
		muscle = GameObject.Find ("Canvas").GetComponent<AttributeHandler> ().muscleSelected;
		lip = GameObject.Find ("Canvas").GetComponent<AttributeHandler> ().lipsSelected;
		head = GameObject.Find ("Canvas").GetComponent<AttributeHandler> ().headSelected;
		ears = GameObject.Find ("Canvas").GetComponent<AttributeHandler> ().earsSelected;
		tail = GameObject.Find ("Canvas").GetComponent<AttributeHandler> ().tailSelected;
		tongue = GameObject.Find ("Canvas").GetComponent<AttributeHandler> ().tongueSelected;
		paw = GameObject.Find ("Canvas").GetComponent<AttributeHandler> ().pawSelected;
		eyes = GameObject.Find ("Canvas").GetComponent<AttributeHandler> ().eyesSelected;
	}

	void checkIfSelected(Toggle t, bool[] bools) {
		// Iterate through bool list and see if any of them are marked true, if so, set flag
		bool flag = false;
		foreach (bool b in bools) {
			if (b) {
				flag = true;
			}
		}
		// change the color of the box to give user feedback
		// Color values = (0, 255, 0, 255)
		if (flag) {
			// print ("Something got turned on");
			ColorBlock toggleColor = t.colors;
			toggleColor.disabledColor = new Color (0, 255, 0, 255);
			t.colors = toggleColor;
		}

	}


}
