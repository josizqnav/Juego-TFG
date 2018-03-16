using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentButtonController : MonoBehaviour {

	//Si está seleccionado
	public bool selected = false;
	//Boton guardado como imagen para poder guardar colores (seleccionado y no seleccionado)
	public Image ImageButtom;
	public Color[] colors;
	//Texto que tendrá el botón
	public Text textEquipment;
	//Guardará los Stats del equipamiento
	public EquipmentStats equipmentStats;

	// Inicializamos la imagen y los colores
	void Start () {
		ImageButtom = GetComponent<Image> ();
		ImageButtom.color = colors [0];
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (selected) {
			ImageButtom.color = colors [1];
			if (Input.GetKeyDown (KeyCode.Z)) {
				if (equipmentStats.typeEquipment == TypeEquipment.Weapon) {
					PlayerState.Instance.savedPlayerEquipment.weapon = equipmentStats;
				} else {
					PlayerState.Instance.savedPlayerEquipment.armor = equipmentStats;
				}

				applyBuff (PlayerState.Instance.savedPlayerStats, PlayerState.Instance.savedBasePlayerStats);
				//Volvemos al menú anterior
				selected = false;
				GameObject actualMenu = GameObject.Find ("ScrollEquipo");
				actualMenu.GetComponent<MenuEquipmentController> ().position = 0;
				actualMenu.SetActive (false);
				GameObject baseMenu = GameObject.Find ("PanelRaizEquipo");
				baseMenu.transform.Find("BotonArma").gameObject.GetComponent<ButtomController>().selected = true;
				baseMenu.GetComponent<MainMenuController> ().enabled = true;
				baseMenu.GetComponent<MainMenuController> ().position = 0;
			}
			if (Input.GetKeyDown (KeyCode.X)) {
				selected = false;
				GameObject actualMenu = GameObject.Find ("ScrollEquipo");
				actualMenu.GetComponent<MenuEquipmentController> ().position = 0;
				actualMenu.SetActive (false);
				GameObject baseMenu = GameObject.Find ("PanelRaizEquipo");
				baseMenu.transform.Find("BotonArma").gameObject.GetComponent<ButtomController>().selected = true;
				baseMenu.GetComponent<MainMenuController> ().enabled = true;
				baseMenu.GetComponent<MainMenuController> ().position = 0;
			}
		} else {
			ImageButtom.color = colors [0];
		}
	}

	//Le damos el texto adecuado al botón
	public void SetupEquipment (EquipmentStats equipment){
		textEquipment.text = equipment.nameObject;
		equipmentStats = equipment;
	}

	private void applyBuff(PlayerStats playerStats, PlayerStats basePlayerStats){
		foreach (Buff buff in equipmentStats.buffs) {
			if (buff.attribute == "strength") {
				playerStats.strength = basePlayerStats.strength + buff.improvement;
			}
			if (buff.attribute == "defense") {
				playerStats.defense = basePlayerStats.defense + buff.improvement;
			}
			if (buff.attribute == "magic") {
				playerStats.magic = basePlayerStats.magic + buff.improvement;
			}
			if (buff.attribute == "speed") {
				playerStats.speed = basePlayerStats.speed + buff.improvement;
			}
		}
	}
}
