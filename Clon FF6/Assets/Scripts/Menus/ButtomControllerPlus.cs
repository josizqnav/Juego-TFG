using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtomControllerPlus : ButtomController {
	
	public GameObject otherMenu;

	void FixedUpdate () {
		if (selected) {
			ImageButtom.color = colors [1];
			//Seleccionamos el personaje deseado
			if (Input.GetKeyDown (KeyCode.Z) && nameButtom == "Personaje1") {
				
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
				otherMenu.transform.Find ("BotonCondicion").GetComponent<ButtomController> ().selected = true;
			}
			//Cuando se pulse Esc
			if (Input.GetKeyDown (KeyCode.Escape)) {
				//Deseleccionamos el boton y seleccionamos condición para que vuelva a iniciarse por defecto
				this.selected = false;
				//Ponemos por defecto el menu personaje
				MainMenuControllerPlus menu = actualMenu.GetComponent<MainMenuControllerPlus>();
				menu.isCondition = false;
				menu.isEquipment = false;
				menu.isMagic = false;
				otherMenu.transform.Find ("BotonCondicion").GetComponent<ButtomController> ().selected = true;
			}
		} else {
			ImageButtom.color = colors [0];
		}
	}
}
