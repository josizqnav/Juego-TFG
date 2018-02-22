using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtomControllerPlus : ButtomController {
	
	public GameObject otherMenu;

	void FixedUpdate () {
		if (selected) {
			ImageButtom.color = colors [1];
			//Seleccionamos el personaje 1
			if (Input.GetKeyDown (KeyCode.Z) && nameButtom == "Personaje1") {
				actualMenu.transform.parent.gameObject.SetActive (false);
				nextMenu.SetActive (true);
				nextMenu.GetComponent<CheckMenuCondition> ().isIsabelle = true;
			}
			if (Input.GetKeyDown (KeyCode.Z) && nameButtom == "Personaje2") {
				actualMenu.transform.parent.gameObject.SetActive (false);
				nextMenu.SetActive (true);
				nextMenu.GetComponent<CheckMenuCondition> ().isIsabelle = false;
			}
			//Si pulsamos X
			if (Input.GetKeyDown (KeyCode.X) && (nameButtom=="Personaje1" ||
				nameButtom=="Personaje2")){
				//Deseleccionamos todo por defecto
				this.selected = false;
				//Reactivamos el menu comandos y desactivamos el actual
				MainMenuControllerPlus menu = actualMenu.GetComponent<MainMenuControllerPlus> ();
				menu.isMagic = false;
				menu.isCondition = false;
				menu.isEquipment = false;
				menu.enabled = false;
				otherMenu.GetComponent<MainMenuController> ().enabled = true;
				//Seleccionamos Condicion
				otherMenu.transform.Find ("BotonCondicion").gameObject.SetActive(true);
			}
		} else {
			ImageButtom.color = colors [0];
		}
	}
}
