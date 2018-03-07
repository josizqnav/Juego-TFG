using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectButtonController : MonoBehaviour {
	//Si está seleccionado
	public bool selected = false;
	//Boton guardado como imagen para poder guardar colores (seleccionado y no seleccionado)
	public Image ImageButtom;
	public Color[] colors;
	//Texto que tendrá el botón
	public Text textObject;


	private CheckScrollObjects scrollObject;
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
				GameObject.Find ("SubmenuObjetos").SetActive (false);
				GameObject.Find ("MenuJugador").transform.GetChild (0).GetChild (0).gameObject.SetActive (true);
			}
		} else {
			ImageButtom.color = colors [0];
		}
	}

	public void Setup (ObjectStats object1){
		textObject.text = object1.nameObject + "\tx" + object1.num;
	}
}
