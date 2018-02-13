using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMenuController : MonoBehaviour {

	public static bool GameIsPaused = false;

	public GameObject characterMenu;

	public GameObject player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			if (GameIsPaused) {
				Resume ();
			} else {
				Pause ();
			}
		}
	}

	void Resume(){
		characterMenu.SetActive (false);
		GameIsPaused = false;
		player.GetComponent<Animator> ().enabled = true;
		player.GetComponent<PlayerController> ().enabled = true;
	}

	public void Pause(){
		characterMenu.SetActive (true);
		GameIsPaused = true;
		player.GetComponent<Animator> ().enabled = false;
		player.GetComponent<PlayerController> ().enabled = false;
	}
}
