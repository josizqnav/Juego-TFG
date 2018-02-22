using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerState : MonoBehaviour {
	//los stats del personaje
	public PlayerStats savedPlayerStats;
	public GameObject player;
	public static PlayerState Instance;

	void Awake ()   
	{
		//Hacemos singleton al jugador
		if (Instance == null)
		{
			DontDestroyOnLoad(gameObject);
			Instance = this;
		}
		else if (Instance != this)
		{
			Destroy (gameObject);
		}
	}
	void Start () {
		//Si la partida es cargada
		if (!GlobalControl.Instance.isNewGame) {
			//Pasamos al personaje los datos cargados.
			savedPlayerStats = GlobalControl.Instance.savedPlayerStats;
			//Asignamos al objeto jugador la posición donde guardó
			Vector3 posicionCargada = new Vector3 (savedPlayerStats.positionX, savedPlayerStats.positionY, 0);
			player.transform.position = posicionCargada;
			//Cargamos la cámara en la escena correspondiente
			Camera.main.GetComponent<MainCamera> ().SetBound (GameObject.Find (savedPlayerStats.mapName));
		} else {
			//Si la partida es nueva, inicializamos todos los stats
			savedPlayerStats.mapName = player.GetComponent<PlayerController>().initialMap.name;
			//Esto se podrá optimizar por json o algo seguro. Solo son los de Isabelle.
			savedPlayerStats.nameCharacter = "Isabelle";
			savedPlayerStats.level = 1;
			savedPlayerStats.maxVitality = 53;
			savedPlayerStats.actualVitality = 53;
			savedPlayerStats.maxMagicPoints = 5;
			savedPlayerStats.actualMagicPoints = 5;
			savedPlayerStats.strength = 40;
			savedPlayerStats.defense = 48;
			savedPlayerStats.magic = 25;
			savedPlayerStats.speed = 28;
			savedPlayerStats.nextLvl = 32;
			savedPlayerStats.actualExp = 0;
		}
	}

	// Update is called once per frame
	void Update () {
		savedPlayerStats.positionX = player.transform.position.x;
		savedPlayerStats.positionY = player.transform.position.y;
		savedPlayerStats.sceneID = SceneManager.GetActiveScene ().buildIndex;
	}
}
