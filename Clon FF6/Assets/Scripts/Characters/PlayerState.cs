using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerState : MonoBehaviour {
	//los stats del personaje
	public PlayerStats savedPlayerStats;
	public List<ObjectStats> savedObjectStats;
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
			initiatePlayers ();
			initiateObjects ();
		}
	}

	// Update is called once per frame
	void Update () {
		savedPlayerStats.positionX = player.transform.position.x;
		savedPlayerStats.positionY = player.transform.position.y;
		savedPlayerStats.sceneID = SceneManager.GetActiveScene ().buildIndex;
	}

	private void initiatePlayers(){
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

	private void initiateObjects(){
		//Objetos
		ObjectStats object1 = new ObjectStats();
		object1.nameObject = "Poción";
		object1.description = "Cura 50 de vitalidad a un aliado";
		object1.damageOrHeal = 50;
		object1.typeObject = TypeObject.HealVT;
		object1.num = 2;

		ObjectStats object2 = new ObjectStats();
		object2.nameObject = "Éter";
		object2.description = "Cura 50 puntos mágicos a un aliado";
		object2.damageOrHeal = 50;
		object2.typeObject = TypeObject.HealPM;
		object2.num = 1;

		ObjectStats object3 = new ObjectStats();
		object3.nameObject = "Ultrapoción";
		object3.description = "Cura 50 puntos mágicos a un aliado";
		object3.damageOrHeal = 50;
		object3.typeObject = TypeObject.HealPM;
		object3.num = 1;

		ObjectStats object4 = new ObjectStats();
		object4.nameObject = "Superpoción";
		object4.description = "Cura 50 puntos mágicos a un aliado";
		object4.damageOrHeal = 50;
		object4.typeObject = TypeObject.HealPM;
		object4.num = 1;

		ObjectStats object5 = new ObjectStats();
		object5.nameObject = "Superéter";
		object5.description = "Cura 50 puntos mágicos a un aliado";
		object5.damageOrHeal = 50;
		object5.typeObject = TypeObject.HealPM;
		object5.num = 1;

		ObjectStats object6 = new ObjectStats();
		object6.nameObject = "Ultraéter";
		object6.description = "Cura 50 puntos mágicos a un aliado";
		object6.damageOrHeal = 50;
		object6.typeObject = TypeObject.HealPM;
		object6.num = 1;

		ObjectStats object7 = new ObjectStats();
		object7.nameObject = "Lanzallamas";
		object7.description = "Cura 50 puntos mágicos a un aliado";
		object7.damageOrHeal = 50;
		object7.typeObject = TypeObject.HealPM;
		object7.num = 1;

		ObjectStats object8 = new ObjectStats();
		object8.nameObject = "Lanzatormenta";
		object8.description = "Cura 50 puntos mágicos a un aliado";
		object8.damageOrHeal = 50;
		object8.typeObject = TypeObject.HealPM;
		object8.num = 1;

		ObjectStats object9 = new ObjectStats();
		object9.nameObject = "Aguja de oro";
		object9.description = "Cura 50 puntos mágicos a un aliado";
		object9.damageOrHeal = 50;
		object9.typeObject = TypeObject.HealPM;
		object9.num = 1;

		ObjectStats object10 = new ObjectStats();
		object10.nameObject = "Antídoto";
		object10.description = "Cura 50 puntos mágicos a un aliado";
		object10.damageOrHeal = 50;
		object10.typeObject = TypeObject.HealPM;
		object10.num = 1;

		ObjectStats object11 = new ObjectStats();
		object11.nameObject = "Colirio";
		object11.description = "Cura 50 puntos mágicos a un aliado";
		object11.damageOrHeal = 50;
		object11.typeObject = TypeObject.HealPM;
		object11.num = 1;

		ObjectStats object12 = new ObjectStats();
		object12.nameObject = "Panecea";
		object12.description = "Cura 50 puntos mágicos a un aliado";
		object12.damageOrHeal = 50;
		object12.typeObject = TypeObject.HealPM;
		object12.num = 1;

		ObjectStats object13 = new ObjectStats();
		object13.nameObject = "Lanzaventisca";
		object13.description = "Lanza un ataque de hielo a un enemigo";
		object13.damageOrHeal = 50;
		object13.typeObject = TypeObject.HealPM;
		object13.num = 1;

		ObjectStats object14 = new ObjectStats();
		object14.nameObject = "Vacuna";
		object14.description = "Cura 50 puntos mágicos a un aliado";
		object14.damageOrHeal = 50;
		object14.typeObject = TypeObject.HealPM;
		object14.num = 1;

		savedObjectStats.Add (object1); savedObjectStats.Add (object2); savedObjectStats.Add (object3);
		savedObjectStats.Add (object4); savedObjectStats.Add (object5); savedObjectStats.Add (object6);
		savedObjectStats.Add (object7); savedObjectStats.Add (object8); savedObjectStats.Add (object9);
		savedObjectStats.Add (object10); savedObjectStats.Add (object11); savedObjectStats.Add (object12);
		savedObjectStats.Add (object13); savedObjectStats.Add (object14);
	}
}
