using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CharacterStats {
	public int sceneID;
	public float positionX, positionY;
	public string nameCharacter;
	public float maxVitality;
	public float actualVitality;
	public float strength;
	public float defense;
	public float speed;
	public string mapName;

	public CharacterStats() {
		this.sceneID = 0;
		this.positionX = 0;
		this.positionY = 0;
		this.nameCharacter = "";
		this.maxVitality = 0;
		this.actualVitality = 0;
		this.strength = 0;
		this.defense = 0;
		this.speed = 0;
		this.mapName = "";
	}
}
