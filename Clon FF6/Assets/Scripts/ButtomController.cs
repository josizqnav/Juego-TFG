using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtomController : MonoBehaviour {
	//Si está seleccionado
	public bool selected = false;
	//Boton guardado como imagen para poder guardar colores (seleccionado y no seleccionado)
	public Image ImageButtom;
	public Color[] colors;
	//Nombre del botón
	public string name;
	public GameObject actualMenu;
	public GameObject nextMenu;

	// Inicializamos la imagen y los colores
	void Start () {
		ImageButtom = GetComponent<Image> ();
		ImageButtom.color = colors [0];
		
	}

	void FixedUpdate () {
		//Si esta seleccionado cambia el color del botón
		if (selected) {
			ImageButtom.color = colors [1];
			//Si elegimos Nuevo juego, iniciamos la siguiente escena
			if (Input.GetKeyDown (KeyCode.Z) && name=="NuevoJuego") {
				SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex +1);
			}
			//Si elegimos cargar o volver, desactivamos el menú actual y activamos el otro
			if (Input.GetKeyDown (KeyCode.Z) && name=="CargarPartida") {
				actualMenu.SetActive (false);
				nextMenu.SetActive(true);
			}
			//Si elegimos Salir, saldremos del juego
			if (Input.GetKeyDown (KeyCode.Z) && name=="Salir") {
				Debug.Log ("Salir del juego");
				Application.Quit ();
			}
		} else {
			ImageButtom.color = colors [0];
		}
			
	}
}
