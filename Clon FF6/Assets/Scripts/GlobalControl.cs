using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GlobalControl : MonoBehaviour {

	public static GlobalControl Instance;
	public GameObject player;
	public PlayerStats savedPlayerStats;
	public bool isNewGame = true;

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

	void Start () {
		
	}
	
	void Update () {
		
	}

	public void saveGame(string nameButton){
		//Recojemos los stats del personaje
		PlayerStats saveData = new PlayerStats();
		saveData = player.GetComponent<PlayerState> ().savedPlayerStats;
		//
		BinaryFormatter bf = new BinaryFormatter();
		//Para guardar en una carpeta local
		//FileStream file = File.Create(Application.persistentDataPath + "/gamesave.save");
		if (!Directory.Exists("Saves"))
			Directory.CreateDirectory("Saves");
		FileStream file;
		if(nameButton == "Guardar1")
			file = File.Create("Saves/gamesave1.save");
		else if(nameButton == "Guardar2")
			file = File.Create("Saves/gamesave2.save");
		else
			file = File.Create("Saves/gamesave3.save");
		bf.Serialize(file, saveData);
		file.Close();

		Debug.Log ("Juego guardado");
	}

	public void loadGame(){
		if (File.Exists ("Saves/gamesave.save")) {
			isNewGame = false;

			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open("Saves/gamesave.save", FileMode.Open);
			PlayerStats saveData = (PlayerStats)bf.Deserialize(file);
			file.Close();

			//player.GetComponent<PlayerState> ().savedPlayerStats = saveData;

			savedPlayerStats = saveData;
			SceneManager.LoadScene (saveData.sceneID);
			Debug.Log ("Juego cargado");
		} else {
			Debug.Log ("No hay partida guardada");
		}
	}
		
}
