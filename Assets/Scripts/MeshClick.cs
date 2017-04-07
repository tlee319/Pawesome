using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MeshClick : MonoBehaviour {

	public Material highlightColor;
	public Material originalColor;

	public string clickedPart;

	GameObject currentPart;
	GameObject lastPart;
	bool hovering;
    bool clicked;
    Vector3 pos;
    Vector3 dfault;

	public GameObject bodyMainButton; //0
	public GameObject muscleMainButton; //1
	public GameObject lipsMainButton; //2
	public GameObject eyesMainButton; //3
	public GameObject headMainButton; //4
	public GameObject earsMainButton; //5
	public GameObject tailMainButton; //6
	public GameObject tongueMainButton; //7
	public GameObject pawMainButton; //8

	public GameObject[] buttons;

	// Use this for initialization
	void Start () {
        dfault = Camera.main.transform.position;
        pos = dfault;

		buttons = new GameObject[]{bodyMainButton, muscleMainButton, lipsMainButton, eyesMainButton, headMainButton, earsMainButton, tailMainButton, tongueMainButton, pawMainButton};

		CloseAllButtons ();
	}

	public void CloseAllButtons() {
		foreach (GameObject b in buttons) {
			b.GetComponent<RectTransform> ().sizeDelta = new Vector2 (0f, 0f);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (!hovering && lastPart != null) {
			lastPart.GetComponent<Renderer> ().material = originalColor;
		}
		hovering = false;

        if (clicked)
        {
            if (Camera.main.transform.position.z - pos.z > -0.001 && Camera.main.transform.position.z - pos.z < 0.001)
            {
                clicked = false;
            }
            Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, pos, 2 * Time.deltaTime);
        }
	}


	void OnMouseOver() {
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); 
		RaycastHit dogHit;
		bool cast = Physics.Raycast (ray, out dogHit, 100);
		if (dogHit.transform.IsChildOf(transform) || dogHit.transform == transform) {
			currentPart = dogHit.collider.gameObject;
			hovering = true;
			Renderer rend = currentPart.GetComponent<Renderer> ();
			if (cast) {
				rend.material = highlightColor;
			}
			if (lastPart != null && currentPart != lastPart) {
				lastPart.GetComponent<Renderer> ().material = originalColor;
			}
			lastPart = currentPart;
		}
	}

    void OnMouseDown()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit dogHit;
        bool cast = Physics.Raycast(ray, out dogHit, 100);
        currentPart = dogHit.collider.gameObject;
        if (cast)
        {
            clicked = true;
        }
        if (currentPart.transform.parent.gameObject.name == "head")
        {
            pos = new Vector3(0.89f, 1.07f, -0.06f);
            Camera.main.transform.rotation = Quaternion.Euler(18.647f, -86.36301f, -7.305f);
            Camera.main.fieldOfView = 27;

			setEverythingToZero ();
			headMainButton.GetComponent<RectTransform> ().sizeDelta = new Vector3 (400f, 50);
        }
        else if (currentPart.transform.parent.gameObject.name == "legs")
        {
            pos = new Vector3(0.762f, 0.423f, -0.272f);
            Camera.main.transform.rotation = Quaternion.Euler(7.968f, -78.414f, 0.476f);

			setEverythingToZero ();
			pawMainButton.GetComponent<RectTransform> ().sizeDelta = new Vector3 (400f, 50);
        }
        else if (currentPart.transform.parent.gameObject.name == "torso")
        {
            pos = new Vector3(0.29f, 0.94f, -0.82f);
            Camera.main.transform.rotation = Quaternion.Euler(21.932f, -30f, -10.122f);
            Camera.main.fieldOfView = 35;

			setEverythingToZero ();
			bodyMainButton.GetComponent<RectTransform> ().sizeDelta = new Vector3 (400f, 50);
        }
        else if (currentPart.name == "tail")
        {
            pos = dfault;
            Camera.main.transform.rotation = Quaternion.Euler(-6.172f, -31.007f, -0.426f);

			setEverythingToZero ();
			tailMainButton.GetComponent<RectTransform> ().sizeDelta = new Vector3 (400f, 50);
        }
		else if (currentPart.name == "eyeLeft" || currentPart.name == "eyeRight")
		{
			pos = new Vector3(0.931f, 1.013f, -0.096f);
			Camera.main.transform.rotation = Quaternion.Euler(18.647f, -86.36301f, -7.305f);

			setEverythingToZero ();
			eyesMainButton.GetComponent<RectTransform> ().sizeDelta = new Vector3 (400f, 50);
		}
		else if (currentPart.name == "leftEar" || currentPart.name == "rightEar")
		{
			pos = new Vector3(0.931f, 1.013f, -0.096f);
			Camera.main.transform.rotation = Quaternion.Euler(18.647f, -86.36301f, -7.305f);

			setEverythingToZero ();
			earsMainButton.GetComponent<RectTransform> ().sizeDelta = new Vector3 (400f, 50);
		}
		else if (currentPart.name == "mouth" )
		{
			pos = new Vector3(0.931f, 1.013f, -0.096f);
			Camera.main.transform.rotation = Quaternion.Euler(18.647f, -86.36301f, -7.305f);

			setEverythingToZero ();
			lipsMainButton.GetComponent<RectTransform> ().sizeDelta = new Vector3 (200f, 50f);
			tongueMainButton.GetComponent<RectTransform> ().sizeDelta = new Vector3 (200f, 50f);
			tongueMainButton.GetComponent<RectTransform> ().anchoredPosition = new Vector3 (0f, -200f); //.position = new Vector3 (0f, -20f);
		}
    }

	void setEverythingToZero() {
		foreach (GameObject b in buttons) {
			b.GetComponent<RectTransform> ().sizeDelta = new Vector2 (0f, 0f);
		}
	}
}
