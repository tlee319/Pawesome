using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DogStartup : MonoBehaviour {
	public GameObject dog;
	private bool go = false;
	// Use this for initialization
	void Start () {
		dog = GameObject.Find ("dogDivided");
	}
	
	// Update is called once per frame
	void Update () {
//		if (!go) {
//			toggleVisibility ();
//	
//		}
	}

//	void toggleVisibility() {
//		go = GameObject.Find ("okButton").GetComponent<Startup> ().canStart;
//		if (!go) {
//			// dog.GetComponentInChildren<MeshCollider> ().enabled = false;
//			Renderer[] renderers = dog.GetComponentsInChildren<Renderer> ();
//			foreach (Renderer r in renderers) {
//				r.enabled = false;
//			}
//		} else {
//			Renderer[] renderers = dog.GetComponentsInChildren<Renderer> ();
//			foreach (Renderer r in renderers) {
//				r.enabled = true;
//			}
//		}
//	
//
//	}

}

