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
			//Si elegimos Salir, saldremos del juego
			if (Input.GetKeyDown (KeyCode.Z) && nameButtom=="Salir") {
				Debug.Log ("Salir del juego");
				Application.Quit ();
			}
			if (Input.GetKeyDown (KeyCode.Z) && nameButtom=="VolverJuego") {
				actualMenu.SetActive (false);
				nextMenu.GetComponent<Animator> ().enabled = true;
				nextMenu.GetComponent<PlayerController> ().enabled = true;
			}
			if (Input.GetKeyDown (KeyCode.Z) && nameButtom=="VolverMenuP") {
				actualMenu.SetActive (false);
				nextMenu.SetActive(true);
			}//A partir de aquí se debe quitar para la primera iteracción.
			//Cuando pulsemos x, se volverá al menú anterior en algunos casos.
			if (Input.GetKeyDown (KeyCode.X)) {
				if (nameButtom == "Cargar1" || nameButtom == "Cargar2" || nameButtom == "Cargar3"
				   || nameButtom == "Guardar1" || nameButtom == "Guardar2" || nameButtom == "Guardar3"
				   || nameButtom == "VolverMenuP") {
					actualMenu.SetActive (false);
					nextMenu.SetActive (true);
				}
			}//Distintas ranuras para cargar la partida
			if (Input.GetKeyDown (KeyCode.Z) && nameButtom=="Cargar1") {
				GlobalControl.Instance.loadGame("Saves/gamesave1.save");
			}
			if (Input.GetKeyDown (KeyCode.Z) && nameButtom=="Cargar2") {
				GlobalControl.Instance.loadGame("Saves/gamesave2.save");
			}
			if (Input.GetKeyDown (KeyCode.Z) && nameButtom=="Cargar3") {
				GlobalControl.Instance.loadGame("Saves/gamesave3.save");
			}//Distintas ranuras para guardar la partida
			if (Input.GetKeyDown (KeyCode.Z) && nameButtom=="Guardar1") {
				GlobalControl.Instance.saveGame("Saves/gamesave1.save");
			}
			if (Input.GetKeyDown (KeyCode.Z) && nameButtom=="Guardar2") {
				GlobalControl.Instance.saveGame("Saves/gamesave2.save");
			}
			if (Input.GetKeyDown (KeyCode.Z) && nameButtom=="Guardar3") {
				GlobalControl.Instance.saveGame("Saves/gamesave3.save");
			}
		} else {
			ImageButtom.color = colors [0];
		}
			
	}
}
