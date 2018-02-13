using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerStats : CharacterStats {

	public float level;
	public float magicPoints;
	public float magic;
	public float nextLvl;

	public PlayerStats () {
		this.level = 0;
		this.magicPoints = 0;
		this.magic = 0;
		this.nextLvl = 0;
	}
}
