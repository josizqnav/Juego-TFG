using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonControllerPlusMagic : ButtomController {
	public MagicStats magic;
	public PlayerStats playerHealer;


	void FixedUpdate () {
		if (selected) {
			if (Input.GetKeyDown (KeyCode.Z) && nameButtom == "ApliMagiaPj1") {
				if (PlayerState.Instance.savedPlayerStats.actualVitality < PlayerState.Instance.savedPlayerStats.maxVitality) {

				}
			}
			//Si pulsamos X al elegir pj para aplicar magia
			if (Input.GetKeyDown (KeyCode.X) && (nameButtom == "ApliMagiaPj1" || nameButtom == "ApliMagiaPj2")) {
				//Dejamos el selector por defecto
				MagicMenuSelectorController menu1 = actualMenu.GetComponent<MagicMenuSelectorController> ();
				this.selected = false;
				menu1.buttoms [0].selected = true;
				menu1.position = 0;

				actualMenu.SetActive (false);
				nextMenu.GetComponent<MenuMagicController> ().enabled = true;
				menu1.buttonSelected.enabled = true;
			}
		}
	}
}
