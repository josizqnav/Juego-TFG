using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoMaxVitOrPm : MonoBehaviour {

	public float displayTime = 1.5f;
	public GameObject actualMenu;
	public GameObject nextMenu;
	public ButtomController button;


	void OnEnable() {
		displayTime = 1.5f;
	}

	void Update () {
		displayTime -= Time.deltaTime;
		if (displayTime <= 0.0) {
			actualMenu.SetActive (false);
			nextMenu.GetComponent<ObjectMenuSelectorController> ().enabled = true;
			button.enabled = true;
		}
	}
}
