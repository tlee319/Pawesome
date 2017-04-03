using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BehavioralAttribute : Attribute {

	// Ignore this class, my original plan changed. This class does nothing.
	private int behaviorNum;
	private string[] listBehavioral = {"Relaxed but concentrating", "Use of paws, nose, mouth", 
		"Engagement in activity", "Proximity", "Concentrating", "Scratching", "Panting",
		"Hair Loss", "Sniffing", "Yawning", "Move into pressure/Escape from pressure",
		"Fidgety(jumping, climbing, rolling", "Look Away", "Stress Signals", "Can be happy, submissive",
		"(Sit Position)"};



	public BehavioralAttribute(int behaviorNum) {
		this.behaviorNum = behaviorNum;
	}

	public string attributeCode() {
		return behaviorNum.ToString ();
	}

	public string attributeDescription() {
		return listBehavioral[behaviorNum];
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
