using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerStats : CharacterStats {

	public float level;
	public float maxMagicPoints;
	public float actualMagicPoints;
	public float magic;
	public float nextLvl;

	public PlayerStats () {
		this.level = 0;
		this.maxMagicPoints = 0;
		this.actualMagicPoints = 0;
		this.magic = 0;
		this.nextLvl = 0;
	}
}
