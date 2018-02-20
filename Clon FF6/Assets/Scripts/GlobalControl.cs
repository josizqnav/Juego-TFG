using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GlobalControl : MonoBehaviour {
	//Atributo Global que persiste en diferentes escenas
	public static GlobalControl Instance;
	//Datos guardados del jugador
	public PlayerStats savedPlayerStats;
	//Comprobará si es una nueva partida o una cargada.
	public bool isNewGame = true;

	void Awake ()   
	{	//Con esto contruímos un objeto singleton que no desaparecerá entre escenas.
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

	public void saveGame(string nameSave){
		//Recojemos los stats del personaje
		PlayerStats saveData = new PlayerStats();
		saveData = PlayerState.Instance.savedPlayerStats;
		BinaryFormatter bf = new BinaryFormatter();

		//Para guardar en una carpeta local
		//FileStream file = File.Create(Application.persistentDataPath + "/gamesave.save");

		//Comrpobamos si la carpeta donde guardaremos los datos existe, si no, la creamos
		if (!Directory.Exists("Saves"))
			Directory.CreateDirectory("Saves");
		//Creamos el fichero a guardar, puede tener la extención que se desee
		FileStream file = File.Create(nameSave);
		//Guarda los datos en el archivo creado
		bf.Serialize(file, saveData);
		//Importante cerrarlo siempre que hayamos serializado
		file.Close();

		Debug.Log ("Juego guardado");
	}

	public void loadGame(string nameSave){
		if (File.Exists (nameSave)) {
			//Se inicia el cargado de partida, el juego no será nuevo por tanto
			isNewGame = false;
			//Deserializamos el archivo y lo guardamos en una variable
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(nameSave, FileMode.Open);
			PlayerStats saveData = (PlayerStats)bf.Deserialize(file);
			file.Close();

			//Pasamos los datos al objeto global y cargamos la escena correspondiente.
			savedPlayerStats = saveData;
			SceneManager.LoadScene (saveData.sceneID);
			Debug.Log ("Juego cargado");
		} else {
			Debug.Log ("No hay partida guardada");
		}
	}
		
}
