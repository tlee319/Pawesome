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

	// Use this for initialization
	void Start () {
		// Grab okay button
		okButton = okBox.GetComponent<Button> ();
		okButton.onClick.AddListener (OnClick);

	}
	
	// Update is called once per frame
	void Update () {
		


	}

	void OnClick() {
		canStart = true;
		// Destroy both text and ok boxes and allow the dog to be interacted with
		Destroy (textBox);
		Destroy (okBox);
	}

}
