using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EquipmentStats : ItemStats {
	public TypeEquipment typeEquipment;
	public List<Buff> buffs;
	public bool inUse;
	public string user;

	public EquipmentStats(){
		typeEquipment = TypeEquipment.Weapon;
		buffs = new List<Buff> ();
		inUse = false;
		user = "";
	}
}
