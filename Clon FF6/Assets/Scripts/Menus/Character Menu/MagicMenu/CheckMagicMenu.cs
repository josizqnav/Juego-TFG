using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckMagicMenu : MonoBehaviour {
	public bool isIsabelle;
	public Text namePj, vitality, pm, level;
	public Image imagePj1, imagePj2;

	void FixedUpdate () {
		if (isIsabelle) {
			namePj.text = "Isabelle";
			vitality.text = PlayerState.Instance.savedPlayerStats.actualVitality + " / " +
				PlayerState.Instance.savedPlayerStats.maxVitality;
			pm.text = PlayerState.Instance.savedPlayerStats.actualMagicPoints + " / " +
				PlayerState.Instance.savedPlayerStats.maxMagicPoints;
			level.text = PlayerState.Instance.savedPlayerStats.level.ToString();
			imagePj1.gameObject.SetActive (true);
			imagePj2.gameObject.SetActive (false);
		} else {
			imagePj1.gameObject.SetActive (false);
			imagePj2.gameObject.SetActive (true);
		}
	}
}
