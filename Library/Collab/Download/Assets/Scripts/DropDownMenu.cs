using UnityEngine.EventSystems;
using UnityEngine;
using System.Collections;

public class DropDownMenu : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {
	// This class is very self explainatory

	public RectTransform container;
	public bool isOpen;

	// Use this for initialization
	void Start () {
		container = transform.FindChild ("Container").GetComponent<RectTransform> ();
		isOpen = true;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 scale = container.localScale;
		scale.y = Mathf.Lerp (scale.y, isOpen ? 1: 0, Time.deltaTime * 12);
		container.localScale = scale;
	}

	public void OnPointerEnter(PointerEventData eventData) {
		isOpen = true;
	}

	public void OnPointerExit(PointerEventData eventData) {
		isOpen = true;
	}
}
