using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckScrollMagic : MonoBehaviour {
	//Contenido del Scroll
	public Transform contentPanel;
	public List<MagicButtonController> buttons;
	public GameObject prefab;

	public void Refresh(){
		RemoveButtons ();
		AddButtons ();
	}

	private void AddButtons () {
		List<MagicStats> liste = PlayerState.Instance.savedMagicStats;
		for (int i = 0; i < liste.Count; i++) 
		{
			MagicStats magic = liste [i];

			GameObject newButton = (GameObject)GameObject.Instantiate(prefab);
			newButton.transform.SetParent(contentPanel);
			newButton.SetActive(true);

			MagicButtonController magicButton = newButton.GetComponent<MagicButtonController> ();
			if (buttons.Count == 0) {
				magicButton.selected = true;
			}
			magicButton.SetupMagic (magic);
			buttons.Add (magicButton);
		}
	}

	private void RemoveButtons(){
		buttons.Clear ();
		for (int i = 0; i < contentPanel.transform.childCount; i++) {
			GameObject.Destroy (contentPanel.GetChild (i).gameObject);
		}
	}
}
