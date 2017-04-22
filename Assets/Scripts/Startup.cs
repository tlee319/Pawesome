using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Startup : MonoBehaviour {
	public GameObject textBox;
	public GameObject okBox;
	public GameObject dogModel;
	Button okButton;
	public bool canStart = false;
	public GameObject startAgainButton;
	public GameObject fullViewButton;

	// Use this for initialization
	void Start () {
		// Grab okay button
		okButton = okBox.GetComponent<Button> ();
		okButton.onClick.AddListener (OnClick);
		startAgainButton = GameObject.Find ("startAgainButton");
		fullViewButton = GameObject.Find ("Full View");

	}
	
	// Update is called once per frame
	void Update () {
		


	}

	void OnClick() {
		canStart = true;
		// Destroy both text and ok boxes and allow the dog to be interacted with
		if (canStart == true) {
			startAgainButton.GetComponent<RectTransform>().anchoredPosition = new Vector2 (0f, 0f);
			fullViewButton.GetComponent<RectTransform>().anchoredPosition = new Vector2 (0f, 0f);
		}
		Destroy (textBox);
		Destroy (okBox);
	}

}
