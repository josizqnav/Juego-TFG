using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyStats : CharacterStats {
	public float exp;

	public EnemyStats () {
		this.exp = 0;
	}
}
