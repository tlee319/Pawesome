using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BehaviorQuestionButtons : MonoBehaviour {
	public int behaviorQuestionNum;
	public GameObject canvas;

	// Use this for initialization
	void Start () {
		behaviorQuestionNum = canvas.GetComponent<AttributeHandler>().behaviorAttributes.Count;
	}

	// Update is called once per frame
	void Update () {
		if (canvas.GetComponent<AttributeHandler>().behaviorAttributes.Count != behaviorQuestionNum) {
			behaviorQuestionNum = canvas.GetComponent<AttributeHandler>().behaviorAttributes.Count;
			for (int x = 0; x < transform.childCount; x++) {
				foreach (string behavior in canvas.GetComponent<AttributeHandler>().behaviorAttributes) {
					if (behavior.Equals (transform.GetChild (x).GetComponentInChildren<Text> ().text)) {
						transform.GetChild (x).GetComponent<Image> ().color = Color.red;
						transform.GetChild (x).GetComponentInChildren<Text> ().color = Color.white;
						break;
					} else if (x == 0){
						transform.GetChild (x).GetComponent<Image> ().color = Color.white;
						transform.GetChild (x).GetComponentInChildren<Text> ().color = Color.black;
					} else {
						transform.GetChild (x).GetComponent<Image> ().color = Color.white;
						transform.GetChild (x).GetComponentInChildren<Text> ().color = Color.black;
					}
				}
			}
		}
	}
}
