using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ObjectStats: ItemStats {
	public TypeObject typeObject;
	public float damageOrHeal;
	public float num;

	public ObjectStats () {
		this.typeObject = TypeObject.HealVT;
		this.damageOrHeal = 0;
		this.num = 0;
	}
}
