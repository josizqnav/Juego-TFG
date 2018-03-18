using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MagicStats : ItemStats {
	public TypeMagic typeMagic;
	public float damageOrHeal;
	public float expensePM;
	public string user;

	public MagicStats () {
		typeMagic = TypeMagic.Heal;
		damageOrHeal = 0;
		expensePM = 0;
		user = "";
	}
}
