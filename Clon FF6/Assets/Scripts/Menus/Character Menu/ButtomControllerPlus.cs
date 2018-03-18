using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtomControllerPlus : ButtomController {
	
	public GameObject conditionMenu;
	public GameObject equipmentMenu;
	public GameObject magicMenu;
	public MainMenuControllerPlus menuSeleccion;

	void FixedUpdate () {
		if (selected) {
			ImageButtom.color = colors [1];
			//Si pulsamos X
			if (Input.GetKeyDown (KeyCode.X) && (nameButtom=="Personaje1" ||
				nameButtom=="Personaje2")){
				//Deseleccionamos el botón
				this.selected = false;
				//Desactivamos el menú actual
				menuSeleccion.isMagic = false;
				menuSeleccion.isCondition = false;
				menuSeleccion.isEquipment = false;
				menuSeleccion.enabled = false;
				//Reactivamos el submenú comandos
				nextMenu.GetComponent<MainMenuController> ().enabled = true;
				//Seleccionamos Condicion
				nextMenu.transform.Find ("BotonCondicion").gameObject.SetActive(true);
			}
			if (menuSeleccion.isCondition) {
				//Seleccionamos el personaje 1
				if (Input.GetKeyDown (KeyCode.Z) && nameButtom == "Personaje1") {
					//Desactivamos el menú raiz al completo (selector de pjs y comandos)
					actualMenu.transform.parent.gameObject.SetActive (false);
					conditionMenu.SetActive (true);
					//Accedemos a los stats de Isabelle
					conditionMenu.GetComponent<CheckMenuCondition> ().isIsabelle = true;
				}
				if (Input.GetKeyDown (KeyCode.Z) && nameButtom == "Personaje2") {
					actualMenu.transform.parent.gameObject.SetActive (false);
					conditionMenu.SetActive (true);
					//Accedemos a los stats de Morgan
					conditionMenu.GetComponent<CheckMenuCondition> ().isIsabelle = false;
				}
			}
			if (menuSeleccion.isEquipment) {
				//Seleccionamos el personaje 1
				if (Input.GetKeyDown (KeyCode.Z) && nameButtom == "Personaje1") {
					//Desactivamos el menú raiz al completo (selector de pjs y comandos)
					actualMenu.transform.parent.gameObject.SetActive (false);
					equipmentMenu.SetActive (true);
					//Accedemos a los stats de Isabelle
					equipmentMenu.GetComponent<CheckEquipmentMenu> ().isIsabelle = true;
				}
				if (Input.GetKeyDown (KeyCode.Z) && nameButtom == "Personaje2") {
					actualMenu.transform.parent.gameObject.SetActive (false);
					equipmentMenu.SetActive (true);
					//Accedemos a los stats de Marlon
					equipmentMenu.GetComponent<CheckEquipmentMenu> ().isIsabelle = false;
				}
			}
			if (menuSeleccion.isMagic) {
				if (Input.GetKeyDown (KeyCode.Z) && nameButtom == "Personaje1") {
					//Desactivamos el menú raiz al completo (selector de pjs y comandos)
					actualMenu.transform.parent.gameObject.SetActive (false);
					magicMenu.SetActive (true);
					//Accedemos a los stats de Isabelle
					magicMenu.GetComponent<CheckMagicMenu> ().isIsabelle = true;
					//Creamos los botones
					CheckScrollMagic checkScrollMagic = magicMenu.transform.Find("ScrollMagia").GetChild(0).GetChild(0).GetComponent<CheckScrollMagic>();
					checkScrollMagic.Refresh ();
				}
				if (Input.GetKeyDown (KeyCode.Z) && nameButtom == "Personaje2") {
					//Desactivamos el menú raiz al completo (selector de pjs y comandos)
					actualMenu.transform.parent.gameObject.SetActive (false);
					magicMenu.SetActive (true);
					//Accedemos a los stats de Isabelle
					magicMenu.GetComponent<CheckMagicMenu> ().isIsabelle = false;
				}
			}
		} else {
			ImageButtom.color = colors [0];
		}
	}
}
