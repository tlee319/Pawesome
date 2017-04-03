using UnityEngine;
using System.Collections;

public class AppearanceAttribute : Attribute {
	// This class inherits the the interface Attribute

	private string bodyPart;
	private int appearanceNum;

	private string[] bodyApp = {"Forward", "Backwards", "Lowered", "Play Bow", "Hackles Raised", "Up Right"};

	private string[] muscleApp = {"Lack of tension", "Tention"};

	private string[] lipsApp = {"Corner of the mouth tightened", "Teeth / gum showing"};

	private string[] eyesApp = {"Dilated pupils", "Whale eyes", "Half moon eyes", "Intense eyes"};

	private string[] headApp = {"Tilited", "Lowered", "Raised", "Erect"};

	private string[] earsApp = {"Relaxed and Neutral", "Erect and tense", "Erect and not tense", "Down, flattend or back", "Forward"};

	private string[] tailApp = {"Lowered", "Relaxed", "Tucked", "Raised", "Enthusiastic tail wag", "Rigid or immobile"};

	private string[] tongueApp = {"Lip licking", "Hyper-Salivation", "Exposed"};

	private string[] pawApp = {"Sweaty", "Lifted"};

	public AppearanceAttribute(string bodyPart, int appearanceNum) {
		this.bodyPart = bodyPart;
		this.appearanceNum = appearanceNum;
	}

	public string attributeType() {
		return "Appearance";
	}

	public string physicalPart() {
		return bodyPart;
	}
		
	public string attributeCode() {
		return bodyPart + appearanceNum;
	}

	public string attributeDescription() {
		switch (bodyPart) {
		// Check for null during code review lol
		case "Body":
			return bodyApp[appearanceNum];
		case "Muscle":
			return muscleApp[appearanceNum];
		case "Lips":
			return lipsApp[appearanceNum];
		case "Eyes":
			return eyesApp[appearanceNum];
		case "Head":
			return headApp[appearanceNum];
		case "Ears":
			return earsApp[appearanceNum];
		case "Tail":
			return tailApp[appearanceNum];
		case "Tongue":
			return tongueApp[appearanceNum];
		case "Paw":
			return pawApp[appearanceNum];
		}

		return "None, Error";
	}
}
