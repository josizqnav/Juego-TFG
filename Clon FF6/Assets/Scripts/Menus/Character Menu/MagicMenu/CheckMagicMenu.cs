using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckMagicMenu : MonoBehaviour {
	public bool isIsabelle;
	public Text textPJ;

	void FixedUpdate () {
		if (isIsabelle) {
			textPJ.text = "Isabelle";
		} else {
			textPJ.text = "Marlon";
		}
	}
}
