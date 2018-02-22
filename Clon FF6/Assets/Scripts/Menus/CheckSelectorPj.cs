using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckSelectorPj : MonoBehaviour {
	public Text name1, nv1, vt1, pm1;

	void Start () {
		name1.text = PlayerState.Instance.savedPlayerStats.nameCharacter;
		nv1.text = PlayerState.Instance.savedPlayerStats.level.ToString();
		vt1.text = PlayerState.Instance.savedPlayerStats.actualVitality + " / " +
		PlayerState.Instance.savedPlayerStats.maxVitality;
		pm1.text = PlayerState.Instance.savedPlayerStats.actualMagicPoints + " / " +
			PlayerState.Instance.savedPlayerStats.maxMagicPoints;
	}
}
