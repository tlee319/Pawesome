using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectColorChange : MonoBehaviour {
	// This class updates the button selection color

	public GameObject bodyContainer;
	public GameObject muscleContainer;
	public GameObject lipsContainer;
	public GameObject eyesContainer;
	public GameObject headContainer;
	public GameObject earsContainer;
	public GameObject tailContainer;
	public GameObject tongueContainer;
	public GameObject pawContainer;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

		//set color for highlighted buttons here
		Color selectColor = new Color(1f, 0.66f, 0.58f, 1f); //currently light red

		if (GetComponent<AttributeHandler> () != null) {
			bool[] bodyGO = GetComponent<AttributeHandler> ().bodySelected;
			for (int x = 0; x < bodyGO.Length; x++) {
				if (bodyGO[x] == true) {
					bodyContainer.transform.GetChild (x).GetComponent<Image> ().color = selectColor;

					//change color and font size of button text
					Text text = bodyContainer.transform.GetChild (x).GetChild (0).GetComponent<Text> ();
					text.color = Color.white;
					text.fontSize = 18;
				} else {
					bodyContainer.transform.GetChild (x).GetComponent<Image> ().color = Color.white;

					//change text color and size back to default
					Text text = bodyContainer.transform.GetChild (x).GetChild (0).GetComponent<Text> ();
					text.color = Color.black;
					text.fontSize = 14;
				}
			}

			bool[] muscleGO = GetComponent<AttributeHandler> ().muscleSelected;
			for (int x = 0; x < muscleGO.Length; x++) {
				if (muscleGO[x] == true) {
					muscleContainer.transform.GetChild (x).GetComponent<Image> ().color = selectColor;

					Text text = muscleContainer.transform.GetChild (x).GetChild (0).GetComponent<Text> ();
					text.color = Color.white;
					text.fontSize = 18;
				} else {
					muscleContainer.transform.GetChild (x).GetComponent<Image> ().color = Color.white;

					Text text = muscleContainer.transform.GetChild (x).GetChild (0).GetComponent<Text> ();
					text.color = Color.black;
					text.fontSize = 14;
				}
			}

			bool[] lipsGO = GetComponent<AttributeHandler> ().lipsSelected;
			for (int x = 0; x < lipsGO.Length; x++) {
				if (lipsGO[x] == true) {
					lipsContainer.transform.GetChild (x).GetComponent<Image> ().color = selectColor;

					Text text = lipsContainer.transform.GetChild (x).GetChild (0).GetComponent<Text> ();
					text.color = Color.white;
					text.fontSize = 18;
				} else {
					lipsContainer.transform.GetChild (x).GetComponent<Image> ().color = Color.white;

					Text text = lipsContainer.transform.GetChild (x).GetChild (0).GetComponent<Text> ();
					text.color = Color.black;
					text.fontSize = 14;
				}
			}
			bool[] eyesGo = GetComponent<AttributeHandler> ().eyesSelected;
			for (int x = 0; x < eyesGo.Length; x++) {
				if (eyesGo[x] == true) {
					eyesContainer.transform.GetChild (x).GetComponent<Image> ().color = selectColor;

					Text text = eyesContainer.transform.GetChild (x).GetChild (0).GetComponent<Text> ();
					text.color = Color.white;
					text.fontSize = 18;
				} else {
					eyesContainer.transform.GetChild (x).GetComponent<Image> ().color = Color.white;


					Text text = eyesContainer.transform.GetChild (x).GetChild (0).GetComponent<Text> ();
					text.color = Color.black;
					text.fontSize = 14;
				}
			}
			bool[] headGO = GetComponent<AttributeHandler> ().headSelected;
			for (int x = 0; x < headGO.Length; x++) {
				if (headGO[x] == true) {
					headContainer.transform.GetChild (x).GetComponent<Image> ().color = selectColor;

					Text text = headContainer.transform.GetChild (x).GetChild (0).GetComponent<Text> ();
					text.color = Color.white;
					text.fontSize = 18;
				} else {
					headContainer.transform.GetChild (x).GetComponent<Image> ().color = Color.white;

					Text text = headContainer.transform.GetChild (x).GetChild (0).GetComponent<Text> ();
					text.color = Color.black;
					text.fontSize = 14;
				}
			}
			bool[] earGO = GetComponent<AttributeHandler> ().earsSelected;
			for (int x = 0; x < earGO.Length; x++) {
				if (earGO[x] == true) {
					earsContainer.transform.GetChild (x).GetComponent<Image> ().color = selectColor;

					Text text = earsContainer.transform.GetChild (x).GetChild (0).GetComponent<Text> ();
					text.color = Color.white;
					text.fontSize = 18;
				} else {
					earsContainer.transform.GetChild (x).GetComponent<Image> ().color = Color.white;

					Text text = earsContainer.transform.GetChild (x).GetChild (0).GetComponent<Text> ();
					text.color = Color.black;
					text.fontSize = 14;
				}
			}
			bool[] tailGO = GetComponent<AttributeHandler> ().tailSelected;
			for (int x = 0; x < tailGO.Length; x++) {
				if (tailGO[x] == true) {
					tailContainer.transform.GetChild (x).GetComponent<Image> ().color = selectColor;

					Text text = tailContainer.transform.GetChild (x).GetChild (0).GetComponent<Text> ();
					text.color = Color.white;
					text.fontSize = 18;
				} else {
					tailContainer.transform.GetChild (x).GetComponent<Image> ().color = Color.white;

					Text text = tailContainer.transform.GetChild (x).GetChild (0).GetComponent<Text> ();
					text.color = Color.black;
					text.fontSize = 14;
				}
			}
			bool[] pawGO = GetComponent<AttributeHandler> ().pawSelected;
			for (int x = 0; x < pawGO.Length; x++) {
				if (pawGO[x] == true) {
					pawContainer.transform.GetChild (x).GetComponent<Image> ().color = selectColor;

					Text text = pawContainer.transform.GetChild (x).GetChild (0).GetComponent<Text> ();
					text.color = Color.white;
					text.fontSize = 18;
				} else {
					pawContainer.transform.GetChild (x).GetComponent<Image> ().color = Color.white;

					Text text = pawContainer.transform.GetChild (x).GetChild (0).GetComponent<Text> ();
					text.color = Color.black;
					text.fontSize = 14;
				}
			}
			bool[] tongueGO = GetComponent<AttributeHandler> ().tongueSelected;
			for (int x = 0; x < tongueGO.Length; x++) {
				if (tongueGO[x] == true) {
					tongueContainer.transform.GetChild (x).GetComponent<Image> ().color = selectColor;

					Text text = tongueContainer.transform.GetChild (x).GetChild (0).GetComponent<Text> ();
					text.color = Color.white;
					text.fontSize = 18;
				} else {
					tongueContainer.transform.GetChild (x).GetComponent<Image> ().color = Color.white;

					Text text = tongueContainer.transform.GetChild (x).GetChild (0).GetComponent<Text> ();
					text.color = Color.black;
					text.fontSize = 14;
				}
			}
		}
	}
}
