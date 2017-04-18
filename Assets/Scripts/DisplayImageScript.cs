using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Created by Jarrod Blanton
public class DisplayImageScript : MonoBehaviour {
	public Button button;
	public Button exitButton;
	public GameObject buttonObject;
	public GameObject exitButtonObject;

	public RawImage image;
	public Texture imgTexture;

	private float timer;
	private bool isPressed = false;
	private bool stillPressed = false;

	public static bool turnOffMeshInteraction = false;

	// Use this for initialization
	void Start () {
		button = GetComponent<Button> ();
		image.enabled = false;

		exitButton = exitButtonObject.GetComponent<Button> ();
		exitButton.onClick.AddListener (OnClick);
		exitButtonObject.SetActive (false);

	}

	// Update is called once per frame
	void Update () {
		// Check if the button is being pressed
		checkPressed ();
		// If the button is being pressed, start a corou
		if (isPressed) {
			// print ("button has been pressed");
			StartCoroutine ("pressTimer");
		}
		// After the coroutine, if the button was still being pressed, then we will display the image example for the attribute
		if (stillPressed) {
			// print ("BUTTON STILL PRESSED");
			displayImage ();
		}
		// isPressed = false;
	}

	void checkPressed() {
		if (GetComponent<CanvasRenderer>().GetColor() == button.colors.pressedColor) {
			isPressed = true;
		}
	}

	// Coroutine that will yield for a second. If the button is still being pressed, then we can display our image.
	IEnumerator pressTimer() {
		yield return new WaitForSeconds (1f);
		if (GetComponent<CanvasRenderer> ().GetColor () == button.colors.pressedColor) {
			stillPressed = true;
		}

	}

	// TODO: Implement displaying the image. Also create an OK button underneath that will destroy both button and image.
	// Image should be centered on the screen. Dog mesh interaction should be disabled. OK button should destroy image and itself
	void displayImage() {
		exitButtonObject.SetActive (true);
		exitButton.onClick.AddListener (OnClick);
		image.enabled = true;
		image.color = new Color (255, 255, 255, 255);

		//turn off highlighting and clicking the mesh
		turnOffMeshInteraction = true;
	}

	// When user clicks on button, sets the booleans to false. pseudo-destroys button and hides image
	void OnClick() {
		stillPressed = false;
		isPressed = false;
		// print("ON CLICK");
		exitButtonObject.SetActive(false);
		image.enabled = false;
		image.color = new Color (255, 255, 255, 0);

		//turn on highlighting and clicking the mesh
		turnOffMeshInteraction = false;

	}


}

