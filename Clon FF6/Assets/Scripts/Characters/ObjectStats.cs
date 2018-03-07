using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ObjectStats {
	public string nameObject;
	public TypeObject typeObject;
	public string description;
	public float damageOrHeal;
	public float num;

	public ObjectStats () {
		this.nameObject = "";
		this.typeObject = TypeObject.HealVT;
		this.description = "";
		this.damageOrHeal = 0;
		this.num = 0;
	}
}
