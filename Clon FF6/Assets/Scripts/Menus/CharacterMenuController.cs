using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMenuController : MonoBehaviour {
	//Si el juego está pausado
	public static bool GameIsPaused = false;
	//Objeto Menú
	public GameObject characterMenu;

	public GameObject player;

	void Update () {
		//Si pulsamos la tecla Escape y el juego está pausado, se reaunuda, si no, se pausa
		if (Input.GetKeyDown (KeyCode.Escape)) {
			if (GameIsPaused) {
				Resume ();
			} else {
				Pause ();
			}
		}
	}

	void Resume(){
		//Desactivamos el menú y reactivamos al jugador
		characterMenu.SetActive (false);
		GameIsPaused = false;
		player.GetComponent<Animator> ().enabled = true;
		player.GetComponent<PlayerController> ().enabled = true;
	}

	void Pause(){
		//Activamos el menú y desactivamos al jugador
		characterMenu.SetActive (true);
		GameIsPaused = true;
		player.GetComponent<Animator> ().enabled = false;
		player.GetComponent<PlayerController> ().enabled = false;
	}
}
