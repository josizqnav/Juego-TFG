using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerState : MonoBehaviour {
	public PlayerStats savedPlayerStats;
	public GameObject player;
	public static PlayerState Instance;

	void Awake ()   
	{
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
	// Use this for initialization
	void Start () {
		//Inicializa lo cargado
		if (!GlobalControl.Instance.isNewGame) {
			savedPlayerStats = GlobalControl.Instance.savedPlayerStats;
			player.GetComponent<PlayerState> ().savedPlayerStats = savedPlayerStats;
			Vector3 posicionCargada = new Vector3 (savedPlayerStats.positionX, savedPlayerStats.positionY, 0);
			player.transform.position = posicionCargada;
			Camera.main.GetComponent<MainCamera> ().SetBound (GameObject.Find (savedPlayerStats.mapName));
		} else {
			savedPlayerStats.mapName = player.GetComponent<PlayerController>().initialMap.name;
			//Esto se podrá optimizar por json o algo seguro. Solo son los de Isabelle.
			savedPlayerStats.nameCharacter = "Isabelle";
			savedPlayerStats.level = 1;
			savedPlayerStats.vitality = 53;
			savedPlayerStats.magicPoints = 5;
			savedPlayerStats.strength = 40;
			savedPlayerStats.defense = 48;
			savedPlayerStats.magic = 25;
			savedPlayerStats.speed = 28;
			savedPlayerStats.nextLvl = 32;
		}
	}

	// Update is called once per frame
	void Update () {
		savedPlayerStats.positionX = player.transform.position.x;
		savedPlayerStats.positionY = player.transform.position.y;
		savedPlayerStats.sceneID = SceneManager.GetActiveScene ().buildIndex;
	}
}
