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
		if (GetComponent<AttributeHandler> () != null) {
			bool[] bodyGO = GetComponent<AttributeHandler> ().bodySelected;
			for (int x = 0; x < bodyGO.Length; x++) {
				if (bodyGO[x] == true) {
					bodyContainer.transform.GetChild (x).GetComponent<Image> ().color = Color.red;
				} else {
					bodyContainer.transform.GetChild (x).GetComponent<Image> ().color = Color.white;
				}
			}

			bool[] muscleGO = GetComponent<AttributeHandler> ().muscleSelected;
			for (int x = 0; x < muscleGO.Length; x++) {
				if (muscleGO[x] == true) {
					muscleContainer.transform.GetChild (x).GetComponent<Image> ().color = Color.red;
				} else {
					muscleContainer.transform.GetChild (x).GetComponent<Image> ().color = Color.white;
				}
			}

			bool[] lipsGO = GetComponent<AttributeHandler> ().lipsSelected;
			for (int x = 0; x < lipsGO.Length; x++) {
				if (lipsGO[x] == true) {
					lipsContainer.transform.GetChild (x).GetComponent<Image> ().color = Color.red;
				} else {
					lipsContainer.transform.GetChild (x).GetComponent<Image> ().color = Color.white;
				}
			}
			bool[] eyesGo = GetComponent<AttributeHandler> ().eyesSelected;
			for (int x = 0; x < eyesGo.Length; x++) {
				if (eyesGo[x] == true) {
					eyesContainer.transform.GetChild (x).GetComponent<Image> ().color = Color.red;
				} else {
					eyesContainer.transform.GetChild (x).GetComponent<Image> ().color = Color.white;
				}
			}
			bool[] headGO = GetComponent<AttributeHandler> ().headSelected;
			for (int x = 0; x < headGO.Length; x++) {
				if (headGO[x] == true) {
					headContainer.transform.GetChild (x).GetComponent<Image> ().color = Color.red;
				} else {
					headContainer.transform.GetChild (x).GetComponent<Image> ().color = Color.white;
				}
			}
			bool[] earGO = GetComponent<AttributeHandler> ().earsSelected;
			for (int x = 0; x < earGO.Length; x++) {
				if (earGO[x] == true) {
					earsContainer.transform.GetChild (x).GetComponent<Image> ().color = Color.red;
				} else {
					earsContainer.transform.GetChild (x).GetComponent<Image> ().color = Color.white;
				}
			}
			bool[] tailGO = GetComponent<AttributeHandler> ().tailSelected;
			for (int x = 0; x < tailGO.Length; x++) {
				if (tailGO[x] == true) {
					tailContainer.transform.GetChild (x).GetComponent<Image> ().color = Color.red;
				} else {
					tailContainer.transform.GetChild (x).GetComponent<Image> ().color = Color.white;
				}
			}
			bool[] pawGO = GetComponent<AttributeHandler> ().pawSelected;
			for (int x = 0; x < pawGO.Length; x++) {
				if (pawGO[x] == true) {
					pawContainer.transform.GetChild (x).GetComponent<Image> ().color = Color.red;
				} else {
					pawContainer.transform.GetChild (x).GetComponent<Image> ().color = Color.white;
				}
			}
			bool[] tongueGO = GetComponent<AttributeHandler> ().tongueSelected;
			for (int x = 0; x < tongueGO.Length; x++) {
				if (tongueGO[x] == true) {
					tongueContainer.transform.GetChild (x).GetComponent<Image> ().color = Color.red;
				} else {
					tongueContainer.transform.GetChild (x).GetComponent<Image> ().color = Color.white;
				}
			}
		}
	}
}
