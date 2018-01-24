using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour {
	Transform target;
	//Variables para controlar los limites superiores e inferiores
	float tLX, tLY, bRX, bRY;

	void Awake () {
		//El objetivo de la cámara será el juegor (Atención a poner el Tag de Terra como Player)
		target = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	void Update () {
		//Se actualiza la posición de la cámara con el movimiento del jugador, siempre respetando los límites del mapa
		transform.position = new Vector3 (Mathf.Clamp (target.position.x, tLX, bRX),
			Mathf.Clamp (target.position.y, bRY, tLY),
			transform.position.z);
	}

	//Establece los límites de la cámara en la zona actual
	public void SetBound (GameObject map) {
		Tiled2Unity.TiledMap config = map.GetComponent<Tiled2Unity.TiledMap> ();
		float cameraSize = Camera.main.orthographicSize;

		tLX = map.transform.position.x + cameraSize;
		tLY = map.transform.position.y - cameraSize;
		bRX = map.transform.position.x + config.NumTilesWide - cameraSize;
		bRY = map.transform.position.y - config.NumTilesHigh + cameraSize;
	}
}
