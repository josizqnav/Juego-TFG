﻿using System.Collections;
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

	// Inicializamos la imagen y los colores
	void Start () {
		ImageButtom = GetComponent<Image> ();
		ImageButtom.color = colors [0];
	}

	void FixedUpdate () {
		if (selected) {
			ImageButtom.color = colors [1];
			//Si pulsamos X volveremos al menú anterior
			if (Input.GetKeyDown (KeyCode.X)) {
				GameObject.Find ("SubmenuObjetos").SetActive (false);
				//No buscamos directamente el menú anterior porque solo podemos buscar GameObjects activos
				GameObject.Find ("MenuJugador").transform.GetChild (0).GetChild (0).gameObject.SetActive (true);
			}
		} else {
			ImageButtom.color = colors [0];
		}
	}
	//Le damos el texto adecuado al botón
	public void Setup (ObjectStats object1){
		textObject.text = object1.nameObject + "\tx" + object1.num;
	}
}