using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoEquipmentController : MonoBehaviour {
	public float displayTime = 1.5f;
	public GameObject actualMenu;
	public GameObject nextMenu;
	public bool isWeapon = false;
	
	void OnEnable() {
		displayTime = 1.5f;
	}

	void Update () {
		displayTime -= Time.deltaTime;
		if (displayTime <= 0.0) {
			actualMenu.SetActive (false);
			nextMenu.GetComponent<MainMenuController> ().enabled = true;
			if (isWeapon) {
				nextMenu.transform.Find("BotonArma").gameObject.GetComponent<ButtomController>().selected = true;
			} else {
				nextMenu.transform.Find("BotonArmadura").gameObject.GetComponent<ButtomController>().selected = true;
			}
		}
	}
}
