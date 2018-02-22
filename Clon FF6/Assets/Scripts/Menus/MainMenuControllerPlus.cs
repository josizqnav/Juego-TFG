using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuControllerPlus : MainMenuController {
	public bool isCondition = false;
	public bool isEquipment = false;
	public bool isMagic = false;

	void Start(){
		this.enabled = false;
	}
}
