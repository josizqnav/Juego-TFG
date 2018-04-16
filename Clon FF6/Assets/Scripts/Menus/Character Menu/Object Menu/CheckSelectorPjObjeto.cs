using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckSelectorPjObjeto : CheckSelectorPj {

	public ObjectStats objectStats;
	public Text textObject, textNumObject;
	
	void OnEnable () {
		textObject.text += "\t" + objectStats.nameObject;
		textNumObject.text += "\t" + objectStats.num;
	}

	void OnDisable () {
		textObject.text = "Objeto:";
		textNumObject.text = "Cantidad:";
	}
}
