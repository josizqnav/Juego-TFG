using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMenuController : MonoBehaviour {
	//Objeto Menú
	public GameObject characterMenu;
	public GameObject player;

	void Update () {
		//Si pulsamos la tecla Escape se pausa el juego
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Pause ();
		}
	}
		
	void Pause(){
		//Activamos el menú y desactivamos al jugador
		characterMenu.SetActive (true);
		player.GetComponent<Animator> ().enabled = false;
		player.GetComponent<PlayerController> ().enabled = false;
	}
}
