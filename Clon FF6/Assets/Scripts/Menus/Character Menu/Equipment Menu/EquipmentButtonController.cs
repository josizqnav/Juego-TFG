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

	// Inicializamos la imagen y los colores
	void Start () {
		ImageButtom = GetComponent<Image> ();
		ImageButtom.color = colors [0];
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (selected) {
			ImageButtom.color = colors [1];
			if (Input.GetKeyDown (KeyCode.X)) {
				GameObject.Find ("ScrollEquipo").SetActive (false);
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
	}
}
