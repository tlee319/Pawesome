using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;

public class AttributeHandler : MonoBehaviour {
	// This class creates appearance attribute objects and adds them to the EmotionLogicEngine

	// These boolean arrays keep track of appearance attributes button selection status (Clicked or unclicked). 
	// These are used to color the attribute buttons red or white to indicate selection
	public bool[] bodySelected;
	public bool[] muscleSelected;
	public bool[] lipsSelected;
	public bool[] eyesSelected;
	public bool[] earsSelected;
	public bool[] tailSelected;
	public bool[] tongueSelected;
	public bool[] headSelected;
	public bool[] pawSelected;

	public string debudVar = "";

	public List<string> behaviorAttributes;

	// Use this for initialization
	// Automatically defaults to all false
	void Start () {
		bodySelected = new bool[6];
		muscleSelected = new bool[2];
		lipsSelected = new bool[2];
		eyesSelected = new bool[4];
		earsSelected = new bool[5];
		tailSelected = new bool[6];
		tongueSelected = new bool[3];
		headSelected = new bool[4];
		pawSelected = new bool[2];

		behaviorAttributes = new List<string> ();
	}
	
	// Update is called once per frame
	void Update () {

	}


	// These are called in OnClick in appearance button game objects
	// If they were selected, an attribute object is created and added
	// If they were deselected, an attribute object is created but used to remove
	// TODO: condense everything in here into one method if we have time. Very low prioirity

	public void CreateAttribute(Button b) {
		string part = b.name.Substring (0,b.name.Length-1);
		string option = b.name.Substring (b.name.Length-1,1);

		if (part.Equals ("Body")) {
			for (int x = 0; x < bodySelected.Length; x++) {
				if (x == Int32.Parse (option)) {
					if (bodySelected [x] == false) {
						EmotionLogic.EmotionLogicEngine.addAttribute (new AppearanceAttribute (part, Int32.Parse(option)));
						bodySelected [x] = true;
					}
				} else {
					if (bodySelected [x] == true) {
						EmotionLogic.EmotionLogicEngine.removeAttribute (new AppearanceAttribute (part, Int32.Parse(option)));
						bodySelected [x] = false;
					}
				}
			}
		} else if (part.Equals ("Muscle")) {
			for (int x = 0; x < muscleSelected.Length; x++) {
				if (x == Int32.Parse (option)) {
					if (muscleSelected [x] == false) {
						EmotionLogic.EmotionLogicEngine.addAttribute (new AppearanceAttribute (part, Int32.Parse(option)));
						muscleSelected [x] = true;
					}
				} else {
					if (muscleSelected [x] == true) {
						EmotionLogic.EmotionLogicEngine.removeAttribute (new AppearanceAttribute (part, Int32.Parse(option)));
						muscleSelected [x] = false;
					}
				}
			}
		} else if (part.Equals ("Lips")) {
			for (int x = 0; x < lipsSelected.Length; x++) {
				if (x == Int32.Parse (option)) {
					if (lipsSelected [x] == false) {
						EmotionLogic.EmotionLogicEngine.addAttribute (new AppearanceAttribute (part, Int32.Parse(option)));
						lipsSelected [x] = true;
					}
				} else {
					if (lipsSelected [x] == true) {
						EmotionLogic.EmotionLogicEngine.removeAttribute (new AppearanceAttribute (part, Int32.Parse(option)));
						lipsSelected [x] = false;
					}
				}
			}
		} else if (part.Equals ("Eyes")) {
			for (int x = 0; x < eyesSelected.Length; x++) {
				if (x == Int32.Parse (option)) {
					if (eyesSelected [x] == false) {
						EmotionLogic.EmotionLogicEngine.addAttribute (new AppearanceAttribute (part, Int32.Parse(option)));
						eyesSelected [x] = true;
					}
				} else {
					if (eyesSelected [x] == true) {
						EmotionLogic.EmotionLogicEngine.removeAttribute (new AppearanceAttribute (part, Int32.Parse(option)));
						eyesSelected [x] = false;
					}
				}
			}
		} else if (part.Equals ("Ears")) {
			for (int x = 0; x < earsSelected.Length; x++) {
				if (x == Int32.Parse (option)) {
					if (earsSelected [x] == false) {
						EmotionLogic.EmotionLogicEngine.addAttribute (new AppearanceAttribute (part, Int32.Parse(option)));
						earsSelected [x] = true;
					}
				} else {
					if (earsSelected [x] == true) {
						EmotionLogic.EmotionLogicEngine.removeAttribute (new AppearanceAttribute (part, Int32.Parse(option)));
						earsSelected [x] = false;
					}
				}
			}
		} else if (part.Equals ("Tail")) {
			for (int x = 0; x < tailSelected.Length; x++) {
				if (x == Int32.Parse (option)) {
					if (tailSelected [x] == false) {
						EmotionLogic.EmotionLogicEngine.addAttribute (new AppearanceAttribute (part, Int32.Parse(option)));
						tailSelected [x] = true;
					}
				} else {
					if (tailSelected [x] == true) {
						EmotionLogic.EmotionLogicEngine.removeAttribute (new AppearanceAttribute (part, Int32.Parse(option)));
						tailSelected [x] = false;
					}
				}
			}
		} else if (part.Equals ("Tongue")) {
			for (int x = 0; x < tongueSelected.Length; x++) {
				if (x == Int32.Parse (option)) {
					if (tongueSelected [x] == false) {
						EmotionLogic.EmotionLogicEngine.addAttribute (new AppearanceAttribute (part, Int32.Parse(option)));
						tongueSelected [x] = true;
					}
				} else {
					if (tongueSelected [x] == true) {
						EmotionLogic.EmotionLogicEngine.removeAttribute (new AppearanceAttribute (part, Int32.Parse(option)));
						tongueSelected [x] = false;
					}
				}
			}
		} else if (part.Equals ("Head")) {
			for (int x = 0; x < headSelected.Length; x++) {
				if (x == Int32.Parse (option)) {
					if (headSelected [x] == false) {
						EmotionLogic.EmotionLogicEngine.addAttribute (new AppearanceAttribute (part, Int32.Parse(option)));
						headSelected [x] = true;
					}
				} else {
					if (headSelected [x] == true) {
						EmotionLogic.EmotionLogicEngine.removeAttribute (new AppearanceAttribute (part, Int32.Parse(option)));
						headSelected [x] = false;
					}
				}
			}
		} else if (part.Equals ("Paw")) {
			for (int x = 0; x < pawSelected.Length; x++) {
				if (x == Int32.Parse (option)) {
					if (pawSelected [x] == false) {
						EmotionLogic.EmotionLogicEngine.addAttribute (new AppearanceAttribute (part, Int32.Parse(option)));
						pawSelected [x] = true;
					}
				} else {
					if (pawSelected [x] == true) {
						EmotionLogic.EmotionLogicEngine.removeAttribute (new AppearanceAttribute (part, Int32.Parse(option)));
						pawSelected [x] = false;
					}
				}
			}
		}
	}

	// Erase this before launch
	/*
	public void CreateBody0Attribute() {
		if (bodySelected [0] == false) {
			EmotionLogic.EmotionLogicEngine.addAttribute (new AppearanceAttribute ("Body", 0));
			bodySelected [0] = true;
		} else {
			EmotionLogic.EmotionLogicEngine.removeAttribute (new AppearanceAttribute ("Body", 0));
			bodySelected [0] = false;
		}
	}
	public void CreateBody1Attribute() {
		if (bodySelected [1] == false) {
			EmotionLogic.EmotionLogicEngine.addAttribute (new AppearanceAttribute ("Body", 1));
			bodySelected [1] = true;
		} else {
			EmotionLogic.EmotionLogicEngine.removeAttribute (new AppearanceAttribute ("Body", 1));
			bodySelected [1] = false;
		}
	}
	public void CreateBody2Attribute() {
		if (bodySelected [2] == false) {
			EmotionLogic.EmotionLogicEngine.addAttribute (new AppearanceAttribute ("Body", 2));
			bodySelected [2] = true;
		} else {
			EmotionLogic.EmotionLogicEngine.removeAttribute (new AppearanceAttribute ("Body", 2));
			bodySelected [2] = false;
		}
	}
	public void CreateBody3Attribute() {
		if (bodySelected [3] == false) {
			EmotionLogic.EmotionLogicEngine.addAttribute (new AppearanceAttribute ("Body", 3));
			bodySelected [3] = true;
		} else {
			EmotionLogic.EmotionLogicEngine.removeAttribute (new AppearanceAttribute ("Body", 3));
			bodySelected [3] = false;
		}
	}
	public void CreateBody4Attribute() {
		if (bodySelected [4] == false) {
			EmotionLogic.EmotionLogicEngine.addAttribute (new AppearanceAttribute ("Body", 4));
			bodySelected [4] = true;
		} else {
			EmotionLogic.EmotionLogicEngine.removeAttribute (new AppearanceAttribute ("Body", 4));
			bodySelected [4] = false;
		}
	}
	public void CreateBody5Attribute() {
		if (bodySelected [5] == false) {
			EmotionLogic.EmotionLogicEngine.addAttribute (new AppearanceAttribute ("Body", 5));
			bodySelected [5] = true;
		} else {
			EmotionLogic.EmotionLogicEngine.removeAttribute (new AppearanceAttribute ("Body", 5));
			bodySelected [5] = false;
		}
	}

	public void CreateMuscle0Attribute() {
		if (muscleSelected [0] == false) {
			EmotionLogic.EmotionLogicEngine.addAttribute (new AppearanceAttribute ("Muscle", 0));
			muscleSelected [0] = true;
		} else {
			EmotionLogic.EmotionLogicEngine.removeAttribute (new AppearanceAttribute ("Muscle", 0));
			muscleSelected [0] = false;
		}
	}
	public void CreateMuscle1Attribute() {
		if (muscleSelected [1] == false) {
			EmotionLogic.EmotionLogicEngine.addAttribute (new AppearanceAttribute ("Muscle", 1));
			muscleSelected [1] = true;
		} else {
			EmotionLogic.EmotionLogicEngine.removeAttribute (new AppearanceAttribute ("Muscle", 1));
			muscleSelected [1] = false;
		}
	}


	public void CreateLips0Attribute() {
		if (lipsSelected [0] == false) {
			EmotionLogic.EmotionLogicEngine.addAttribute (new AppearanceAttribute ("Lips", 0));
			lipsSelected [0] = true;
		} else {
			EmotionLogic.EmotionLogicEngine.removeAttribute (new AppearanceAttribute ("Lips", 0));
			lipsSelected [0] = false;
		}
	}
	public void CreateLips1Attribute() {
		if (lipsSelected [1] == false) {
			EmotionLogic.EmotionLogicEngine.addAttribute (new AppearanceAttribute ("Lips", 1));
			lipsSelected [1] = true;
		} else {
			EmotionLogic.EmotionLogicEngine.removeAttribute (new AppearanceAttribute ("Lips", 1));
			lipsSelected [1] = false;
		}
	}


	public void CreateEyes0Attribute() {
		if (eyesSelected [0] == false) {
			EmotionLogic.EmotionLogicEngine.addAttribute (new AppearanceAttribute ("Eyes", 0));
			eyesSelected [0] = true;
		} else {
			EmotionLogic.EmotionLogicEngine.removeAttribute (new AppearanceAttribute ("Eyes", 0));
			eyesSelected [0] = false;
		}
	}
	public void CreateEyes1Attribute() {
		if (eyesSelected [1] == false) {
			EmotionLogic.EmotionLogicEngine.addAttribute (new AppearanceAttribute ("Eyes", 1));
			eyesSelected [1] = true;
		} else {
			EmotionLogic.EmotionLogicEngine.removeAttribute (new AppearanceAttribute ("Eyes", 1));
			eyesSelected [1] = false;
		}
	}
	public void CreateEyes2Attribute() {
		if (eyesSelected [2] == false) {
			EmotionLogic.EmotionLogicEngine.addAttribute (new AppearanceAttribute ("Eyes", 2));
			eyesSelected [2] = true;
		} else {
			EmotionLogic.EmotionLogicEngine.removeAttribute (new AppearanceAttribute ("Eyes", 2));
			eyesSelected [2] = false;
		}
	}
	public void CreateEyes3Attribute() {
		if (eyesSelected [3] == false) {
			EmotionLogic.EmotionLogicEngine.addAttribute (new AppearanceAttribute ("Eyes", 3));
			eyesSelected [3] = true;
		} else {
			EmotionLogic.EmotionLogicEngine.removeAttribute (new AppearanceAttribute ("Eyes", 3));
			eyesSelected [3] = false;
		}
	}
		

	public void CreateEars0Attribute() {
		if (earsSelected [0] == false) {
			EmotionLogic.EmotionLogicEngine.addAttribute (new AppearanceAttribute ("Ears", 0));
			earsSelected [0] = true;
		} else {
			EmotionLogic.EmotionLogicEngine.removeAttribute (new AppearanceAttribute ("Ears", 0));
			earsSelected [0] = false;
		}
	}
	public void CreateEars1Attribute() {
		if (earsSelected [1] == false) {
			EmotionLogic.EmotionLogicEngine.addAttribute (new AppearanceAttribute ("Ears", 1));
			earsSelected [1] = true;
		} else {
			EmotionLogic.EmotionLogicEngine.removeAttribute (new AppearanceAttribute ("Ears", 1));
			earsSelected [1] = false;
		}
	}
	public void CreateEars2Attribute() {
		if (earsSelected [2] == false) {
			EmotionLogic.EmotionLogicEngine.addAttribute (new AppearanceAttribute ("Ears", 2));
			earsSelected [2] = true;
		} else {
			EmotionLogic.EmotionLogicEngine.removeAttribute (new AppearanceAttribute ("Ears", 2));
			earsSelected [2] = false;
		}
	}
	public void CreateEars3Attribute() {
		if (earsSelected [3] == false) {
			EmotionLogic.EmotionLogicEngine.addAttribute (new AppearanceAttribute ("Ears", 3));
			earsSelected [3] = true;
		} else {
			earsSelected [3] = false;
		}
	}
	public void CreateEars4Attribute() {
		if (earsSelected [4] == false) {
			EmotionLogic.EmotionLogicEngine.addAttribute (new AppearanceAttribute ("Ears", 4));
			earsSelected [4] = true;
		} else {
			EmotionLogic.EmotionLogicEngine.removeAttribute (new AppearanceAttribute ("Ears", 4));
			earsSelected [4] = false;
		}
	}


	public void CreateTail0Attribute() {
		if (tailSelected [0] == false) {
			EmotionLogic.EmotionLogicEngine.addAttribute (new AppearanceAttribute ("Tail", 0));
			tailSelected [0] = true;
		} else {
			EmotionLogic.EmotionLogicEngine.removeAttribute (new AppearanceAttribute ("Tail", 0));
			tailSelected [0] = false;
		}
	}
	public void CreateTail1Attribute() {
		if (tailSelected [1] == false) {
			EmotionLogic.EmotionLogicEngine.addAttribute (new AppearanceAttribute ("Tail", 1));
			tailSelected [1] = true;
		} else {
			EmotionLogic.EmotionLogicEngine.removeAttribute (new AppearanceAttribute ("Tail", 1));
			tailSelected [1] = false;
		}
	}
	public void CreateTail2Attribute() {
		if (tailSelected [2] == false) {
			EmotionLogic.EmotionLogicEngine.addAttribute (new AppearanceAttribute ("Tail", 2));
			tailSelected [2] = true;
		} else {
			EmotionLogic.EmotionLogicEngine.removeAttribute (new AppearanceAttribute ("Tail", 2));
			tailSelected [2] = false;
		}
	}
	public void CreateTail3Attribute() {
		if (tailSelected [3] == false) {
			EmotionLogic.EmotionLogicEngine.addAttribute (new AppearanceAttribute ("Tail", 3));
			tailSelected [3] = true;
		} else {
			EmotionLogic.EmotionLogicEngine.removeAttribute (new AppearanceAttribute ("Tail", 3));
			tailSelected [3] = false;
		}
	}
	public void CreateTail4Attribute() {
		if (tailSelected [4] == false) {
			EmotionLogic.EmotionLogicEngine.addAttribute (new AppearanceAttribute ("Tail", 4));
			tailSelected [4] = true;
		} else {
			EmotionLogic.EmotionLogicEngine.removeAttribute (new AppearanceAttribute ("Tail", 4));
			tailSelected [4] = false;
		}
	}
	public void CreateTail5Attribute() {
		if (tailSelected [5] == false) {
			EmotionLogic.EmotionLogicEngine.addAttribute (new AppearanceAttribute ("Tail", 5));
			tailSelected [5] = true;
		} else {
			EmotionLogic.EmotionLogicEngine.removeAttribute (new AppearanceAttribute ("Tail", 5));
			tailSelected [5] = false;
		}
	}


	public void CreateTongue0Attribute() {
		if (tongueSelected [0] == false) {
			EmotionLogic.EmotionLogicEngine.addAttribute (new AppearanceAttribute ("Tongue", 0));
			tongueSelected [0] = true;
		} else {
			EmotionLogic.EmotionLogicEngine.removeAttribute (new AppearanceAttribute ("Tongue", 0));
			tongueSelected [0] = false;
		}
	}
	public void CreateTongue1Attribute() {
		if (tongueSelected [1] == false) {
			EmotionLogic.EmotionLogicEngine.addAttribute (new AppearanceAttribute ("Tongue", 1));
			tongueSelected [1] = true;
		} else {
			EmotionLogic.EmotionLogicEngine.removeAttribute (new AppearanceAttribute ("Tongue", 1));
			tongueSelected [1] = false;
		}
	}
	public void CreateTongue2Attribute() {
		if (tongueSelected [2] == false) {
			EmotionLogic.EmotionLogicEngine.addAttribute (new AppearanceAttribute ("Tongue", 2));
			tongueSelected [2] = true;
		} else {
			EmotionLogic.EmotionLogicEngine.removeAttribute (new AppearanceAttribute ("Tongue", 2));
			tongueSelected [2] = false;
		}
	}


	public void CreateHead0Attribute() {
		if (headSelected [0] == false) {
			EmotionLogic.EmotionLogicEngine.addAttribute (new AppearanceAttribute ("Head", 0));
			headSelected [0] = true;
		} else {
			EmotionLogic.EmotionLogicEngine.removeAttribute (new AppearanceAttribute ("Head", 0));
			headSelected [0] = false;
		}
	}
	public void CreateHead1Attribute() {
		if (headSelected [1] == false) {
			EmotionLogic.EmotionLogicEngine.addAttribute (new AppearanceAttribute ("Head", 1));
			headSelected [1] = true;
		} else {
			EmotionLogic.EmotionLogicEngine.removeAttribute (new AppearanceAttribute ("Head", 1));
			headSelected [1] = false;
		}
	}
	public void CreateHead2Attribute() {
		if (headSelected [2] == false) {
			EmotionLogic.EmotionLogicEngine.addAttribute (new AppearanceAttribute ("Head", 2));
			headSelected [2] = true;
		} else {
			EmotionLogic.EmotionLogicEngine.removeAttribute (new AppearanceAttribute ("Head", 2));
			headSelected [2] = false;
		}
	}
	public void CreateHead3Attribute() {
		if (headSelected [3] == false) {
			EmotionLogic.EmotionLogicEngine.addAttribute (new AppearanceAttribute ("Head", 3));
			headSelected [3] = true;
		} else {
			EmotionLogic.EmotionLogicEngine.removeAttribute (new AppearanceAttribute ("Head", 3));
			headSelected [3] = false;
		}
	}
		
	public void CreatePaw0Attribute() {
		if (pawSelected [0] == false) {
			EmotionLogic.EmotionLogicEngine.addAttribute (new AppearanceAttribute ("Paw", 0));
			pawSelected [0] = true;
		} else {
			EmotionLogic.EmotionLogicEngine.removeAttribute (new AppearanceAttribute ("Paw", 0));
			pawSelected [0] = false;
		}
	}
	public void CreatePaw1Attribute() {
		if (pawSelected [1] == false) {
			EmotionLogic.EmotionLogicEngine.addAttribute (new AppearanceAttribute ("Paw", 1));
			pawSelected [1] = true;
		} else {
			EmotionLogic.EmotionLogicEngine.removeAttribute (new AppearanceAttribute ("Paw", 1));
			pawSelected [1] = false;
		}
	}
	*/

	public void BehaviorAttributeHandler(Button b) {
		if (b.GetComponentInChildren<Text> ().text.Contains ("Choose behaviors that you observe. Current possible emotions:") == false) {
			if (behaviorAttributes.Contains (b.GetComponentInChildren<Text> ().text) == true) {
				behaviorAttributes.Remove (b.GetComponentInChildren<Text> ().text);
			} else {
				behaviorAttributes.Add (b.GetComponentInChildren<Text> ().text);
			}
		}
	}
}
