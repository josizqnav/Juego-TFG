using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuEquipmentController : MonoBehaviour {
	public CheckScrollEquipment checkScrollEquipment;
	public List<EquipmentButtonController> buttons;
	public int position = 0;
	//Para controlar la barra
	public Scrollbar scrollRect;
	public Text strengthNext, defenseNext, magicNext, speedNext, descriptionText;

	void FixedUpdate(){
		if (Input.GetKeyDown (KeyCode.X) || Input.GetKeyDown (KeyCode.Z)) {
			strengthNext.text = "";
			defenseNext.text = "";
			magicNext.text = "";
			speedNext.text = "";
		}
	}

	void Update () {
		buttons = checkScrollEquipment.buttons;
		//Cuando pulsemos la tecla flecha abajo
		if (Input.GetKeyDown (KeyCode.DownArrow)) {
			//Deseleccionamos el botón actual y sumamos una posición (bajamos)
			buttons [position].selected = false;
			position++;
			//Si nos encontramos en la primera posición (0) no podemos subir más
			if (position < 0) {
				position = 0;
				buttons [position].selected = true;
				return;
			}
			//Si nos econtramos en la última posición (longitud del array) no podemos bajar más
			if (position > buttons.Count - 1) {
				position = buttons.Count - 1;
				buttons [position].selected = true;
				return;
			}
			//Marcamos como seleccionado el siguiente botón
			buttons [position].selected = true;
		}

		//Si pulsamos la tecla flecha arriba, se hará lo mismo pero restando posición
		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			//Deseleccionamos el botón actual y sumamos una posición (bajamos)
			buttons [position].selected = false;
			position--;
			//Si nos encontramos en la primera posición (0) no podemos subir más
			if (position < 0) {
				position = 0;
				buttons [position].selected = true;
				return;
			}
			//Si nos econtramos en la última posición (longitud del array) no podemos bajar más
			if (position > buttons.Count - 1) {
				position = buttons.Count - 1;
				buttons [position].selected = true;
				return;
			}
			buttons [position].selected = true;
		}
		//Actualizamos la posición del scroll
		controlScroll ();
		controlNextStats ();
	}

	//Controlará el movimiento del scroll conforme se baje o suba en la lista
	private void controlScroll(){
		//Obtenemos el valor máximo de Y
		float maxY = buttons.Count-1;
		//Actualizamos la posición del scroll
		scrollRect.value = 1.0f - (position / maxY);
	}

	private void controlNextStats(){
		EquipmentStats equipmentStats = buttons [position].equipmentStats;
		descriptionText.text = equipmentStats.description;
		strengthNext.text = PlayerState.Instance.savedPlayerStats.strength.ToString();
		defenseNext.text = PlayerState.Instance.savedPlayerStats.defense.ToString();
		magicNext.text = PlayerState.Instance.savedPlayerStats.magic.ToString();
		speedNext.text = PlayerState.Instance.savedPlayerStats.speed.ToString();
		strengthNext.color = Color.white;
		defenseNext.color = Color.white;
		magicNext.color = Color.white;
		speedNext.color = Color.white;
		foreach (Buff buff in equipmentStats.buffs) {
			if (buff.attribute == "strength") {
				strengthNext.text = (PlayerState.Instance.savedBasePlayerStats.strength + buff.improvement).ToString ();
				strengthNext.color = Color.cyan;
			}
			if (buff.attribute == "defense") {
				defenseNext.text = (PlayerState.Instance.savedBasePlayerStats.defense + buff.improvement).ToString ();
				defenseNext.color = Color.cyan;
			}
			if (buff.attribute == "magic") {
				magicNext.text = (PlayerState.Instance.savedBasePlayerStats.magic + buff.improvement).ToString ();
				magicNext.color = Color.cyan;
			}
			if (buff.attribute == "speed") {
				speedNext.text = (PlayerState.Instance.savedBasePlayerStats.speed + buff.improvement).ToString ();
				speedNext.color = Color.cyan;
			}
		}
	}
		
}
