using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckEquipmentMenu : MonoBehaviour {
	public Text weaponText, armorText, strengthPrev, defensePrev, magicPrev, speedPrev, 
	strengthNext, defenseNext, magicNext, speedNext;
	public Image imageP1, imageP2;
	public bool isIsabelle;

	void FixedUpdate () {
		if (isIsabelle) {
			//Activamos la imagen correspondiende y añadimos el valor adecuado a los atributos
			imageP1.gameObject.SetActive (true);
			imageP2.gameObject.SetActive(false);
			strengthPrev.text = PlayerState.Instance.savedPlayerStats.strength.ToString ();
			defensePrev.text = PlayerState.Instance.savedPlayerStats.defense.ToString ();
			magicPrev.text = PlayerState.Instance.savedPlayerStats.magic.ToString ();
			speedPrev.text = PlayerState.Instance.savedPlayerStats.speed.ToString ();
			//Comprobamos su Equipo actual
			PlayerEquipment playerEquipment = PlayerState.Instance.savedPlayerEquipment;
			if (!string.IsNullOrEmpty(playerEquipment.weapon.nameObject)) {
				weaponText.text = playerEquipment.weapon.nameObject;
			}
			if (!string.IsNullOrEmpty(playerEquipment.armor.nameObject)) {
				armorText.text = playerEquipment.armor.nameObject;
			}
			if (string.IsNullOrEmpty(playerEquipment.weapon.nameObject)) {
				weaponText.text = "Nada";
			}
			if (string.IsNullOrEmpty(playerEquipment.armor.nameObject)) {
				armorText.text = "Nada";
			}
		}
	}
}
