using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckMenuCondition : MonoBehaviour {
	public bool isIsabelle;
	public GameObject actualMenu;
	public GameObject nextMenu;
	public Image imageP1, imageP2;
	public Text nv, vt, pm, exp, strength, defense, magic, speed, name1;


	void FixedUpdate () {
		//Si el personaje es Isabelle
		if (isIsabelle) {
			//Si pulsamos X volvemos al menu anterior
			if (Input.GetKeyDown (KeyCode.X)) {
				actualMenu.SetActive (false);
				nextMenu.SetActive(true);
			}
			//Activamos la imagen correspondiende y añadimos el valor adecuado a los atributos
			imageP1.gameObject.SetActive (true);
			imageP2.gameObject.SetActive(false);
			nv.text = PlayerState.Instance.savedPlayerStats.level.ToString();
			vt.text = PlayerState.Instance.savedPlayerStats.actualVitality + " / " +
				PlayerState.Instance.savedPlayerStats.maxVitality;
			pm.text = PlayerState.Instance.savedPlayerStats.actualMagicPoints + " / " +
				PlayerState.Instance.savedPlayerStats.maxMagicPoints;
			exp.text = (PlayerState.Instance.savedPlayerStats.nextLvl -
				PlayerState.Instance.savedPlayerStats.actualExp).ToString ();
			strength.text = PlayerState.Instance.savedPlayerStats.strength.ToString ();
			defense.text = PlayerState.Instance.savedPlayerStats.defense.ToString ();
			magic.text = PlayerState.Instance.savedPlayerStats.magic.ToString ();
			speed.text = PlayerState.Instance.savedPlayerStats.speed.ToString ();
			name1.text = PlayerState.Instance.savedPlayerStats.nameCharacter;
		}//Si el personaje es Marlon 
		else {
			if (Input.GetKeyDown (KeyCode.X)) {
				actualMenu.SetActive (false);
				nextMenu.SetActive(true);
			}
			imageP1.gameObject.SetActive (false);
			imageP2.gameObject.SetActive(true);
		}
	}
}
