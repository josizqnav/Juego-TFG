using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Buff {
	public string attribute;
	public int improvement;

	public Buff(){
		attribute = "";
		improvement = 0;
	}

	public Buff(string attribute, int improvement){
		this.attribute = attribute;
		this.improvement = improvement;
	}
}
