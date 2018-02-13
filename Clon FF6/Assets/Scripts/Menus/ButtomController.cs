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
	public string nameButtom;
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
			//ImageButtom.sprite = sprites [1];
			//Si elegimos Nuevo juego, iniciamos la siguiente escena
			if (Input.GetKeyDown (KeyCode.Z) && nameButtom=="NuevoJuego") {
				SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex +1);
			}
			//Si elegimos cargar o volver, desactivamos el menú actual y activamos el otro
			if (Input.GetKeyDown (KeyCode.Z) && nameButtom=="CambiarMenu") {
				actualMenu.SetActive (false);
				nextMenu.SetActive(true);
			}
			if (Input.GetKeyDown (KeyCode.Z) && nameButtom=="Cargar") {
				//Hacer esto en menú cargar. Ahora mismo se hace en Cargar Partida,
				//aquí se debe sustituir por CambiarMenu
				GlobalControl.Instance.loadGame ();
			}
			//Si elegimos Salir, saldremos del juego
			if (Input.GetKeyDown (KeyCode.Z) && nameButtom=="Salir") {
				Debug.Log ("Salir del juego");
				Application.Quit ();
			}
			if (Input.GetKeyDown (KeyCode.Z) && nameButtom=="VolverJuego") {
				actualMenu.SetActive (false);
				nextMenu.GetComponent<Animator> ().enabled = true;
				nextMenu.GetComponent<PlayerController> ().enabled = true;
			}//Los botones Guardar se quitán para la primera iteracción
			if (Input.GetKeyDown (KeyCode.Z) && nameButtom=="Guardar1") {
				GlobalControl.Instance.saveGame("Guardar1");
			}
			if (Input.GetKeyDown (KeyCode.Z) && nameButtom=="Guardar2") {
				GlobalControl.Instance.saveGame("Guardar2");
			}
			if (Input.GetKeyDown (KeyCode.Z) && nameButtom=="Guardar3") {
				GlobalControl.Instance.saveGame("Guardar3");
			}
			if (Input.GetKeyDown (KeyCode.X) && nameButtom=="Guardar1") {
				actualMenu.SetActive (false);
				nextMenu.SetActive(true);
			}
			if (Input.GetKeyDown (KeyCode.X) && nameButtom=="Guardar2") {
				actualMenu.SetActive (false);
				nextMenu.SetActive(true);
			}
			if (Input.GetKeyDown (KeyCode.X) && nameButtom=="Guardar3") {
				actualMenu.SetActive (false);
				nextMenu.SetActive(true);
			}
		} else {
			ImageButtom.color = colors [0];
		}
			
	}
}
