using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CheckSaveMenu : MonoBehaviour {
	public GameObject text1b1;
	public GameObject text2b1;
	public GameObject text1b2;
	public GameObject text2b2;
	public GameObject text1b3;
	public GameObject text2b3;

	// Use this for initialization
	void Start () {
		
	}

	void Update () {
		if (File.Exists ("Saves/gamesave1.save")) {
			text1b1.SetActive (false);
			text2b1.SetActive (true);
		}
		if (!File.Exists ("Saves/gamesave1.save")) {
			text1b1.SetActive (true);
			text2b1.SetActive (false);
		}
		if (File.Exists ("Saves/gamesave2.save")) {
			text1b2.SetActive (false);
			text2b2.SetActive (true);
		}
		if (!File.Exists ("Saves/gamesave2.save")) {
			text1b2.SetActive (true);
			text2b2.SetActive (false);
		}
		if (File.Exists ("Saves/gamesave3.save")) {
			text1b3.SetActive (false);
			text2b3.SetActive (true);
		}
		if (!File.Exists ("Saves/gamesave3.save")) {
			text1b3.SetActive (true);
			text2b3.SetActive (false);
		}

	}
}
