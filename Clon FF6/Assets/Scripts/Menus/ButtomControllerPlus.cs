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
				//Desactivamos el menú raiz al completo (selector de pjs y comandos)
				actualMenu.transform.parent.gameObject.SetActive (false);
				nextMenu.SetActive (true);
				//Accedemos a los stats de Isabelle
				nextMenu.GetComponent<CheckMenuCondition> ().isIsabelle = true;
			}
			if (Input.GetKeyDown (KeyCode.Z) && nameButtom == "Personaje2") {
				actualMenu.transform.parent.gameObject.SetActive (false);
				nextMenu.SetActive (true);
				//Accedemos a los stats de Morgan
				nextMenu.GetComponent<CheckMenuCondition> ().isIsabelle = false;
			}
			//Si pulsamos X
			if (Input.GetKeyDown (KeyCode.X) && (nameButtom=="Personaje1" ||
				nameButtom=="Personaje2")){
				//Deseleccionamos el botón
				this.selected = false;
				//Desactivamos el menú actual
				MainMenuControllerPlus menu = actualMenu.GetComponent<MainMenuControllerPlus> ();
				//Ponemos por defecto los atributos
				menu.isMagic = false;
				menu.isCondition = false;
				menu.isEquipment = false;
				menu.enabled = false;
				//Reactivamos el submenú comandos
				otherMenu.GetComponent<MainMenuController> ().enabled = true;
				//Seleccionamos Condicion
				otherMenu.transform.Find ("BotonCondicion").gameObject.SetActive(true);
			}
		} else {
			ImageButtom.color = colors [0];
		}
	}
}
