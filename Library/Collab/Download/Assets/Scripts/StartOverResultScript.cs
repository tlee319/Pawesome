using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartOverResultScript : MonoBehaviour {

	Button startButton;
	public GameObject buttonObject;
	public GameObject canvas;
	public bool resultDisplaying = false;
	public Text text;

	// Use this for initialization
	void Start () {
		buttonObject = GameObject.Find ("startAgainButton");
		startButton = buttonObject.GetComponent<Button> ();
		canvas = GameObject.Find ("Canvas");

	}
	
	// Update is called once per frame
	void Update () {
		// Check if result is being displayed
		if (canvas.GetComponent<EmotionLogic>().displayResult) {
			displayButton ();
		}
	}

	// Moves the button and changes attribute values to match display
	void displayButton() {

		// Set Colors for start button to 0 alpha
		ColorBlock buttonColors = startButton.colors;
		buttonColors.normalColor = new Color (255, 255, 255, 0);
		buttonColors.highlightedColor = new Color(255, 255, 255, 0);
		startButton.colors = buttonColors;

		// Change button size
		buttonObject.GetComponent<RectTransform> ().sizeDelta = new Vector2 (851, 100);

		// Change text size and rect transform information to fit in new button shape
		text = buttonObject.GetComponentInChildren<Text> ();
		text.GetComponent<RectTransform>().sizeDelta = new Vector2(851, 100);
		text.fontSize = 50;
		text.color = new Color (255, 255, 255, 255);

		Camera.main.transform.position = new Vector3 (0, 0, 0);
		Camera.main.transform.rotation = Quaternion.Euler (0, 0, 0);

	}
}
