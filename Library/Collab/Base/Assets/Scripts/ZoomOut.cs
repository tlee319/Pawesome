using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ZoomOut : MonoBehaviour {

    public Button fullView;
    public Camera main;
	public GameObject behaviorQuestions;
    public bool clicked;

    public MeshClick zoom;

    private Vector3 pos;
    private Vector3 camPos;
    private bool moving;

	// Use this for initialization
	void Start () {
        fullView = gameObject.GetComponent<Button>();
        fullView.onClick.AddListener(TaskOnClick);
        pos = main.transform.position;
        camPos = main.transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        if (camPos != main.transform.position)
        {
            moving = true;
        } else
        {
            moving = false;
        }
        camPos = main.transform.position;
        if (zoom.clicked)
        {
            clicked = false;
        }
        if (clicked)
        {
            main.transform.position = Vector3.Lerp(main.transform.position, pos, 5 * Time.deltaTime);
            main.transform.rotation = Quaternion.Euler(-6.172f, -31.007f, -0.426f);
            main.fieldOfView = 35;
        }
        if (Camera.main.transform.position.z - pos.z > -0.001 && Camera.main.transform.position.z - pos.z < 0.001)
        {
            clicked = false;
        }

    }

    

    private void TaskOnClick()
    {
		
            zoom.clicked = false;
			clicked = true;
		
    }
}
