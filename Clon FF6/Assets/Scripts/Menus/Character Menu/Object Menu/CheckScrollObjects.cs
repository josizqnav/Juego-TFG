using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckScrollObjects : MonoBehaviour {
	//Contenido del Scroll
	public Transform contentPanel;
	public GameObject prefab;
	//Lista de botones
	public List<ObjectButtonController> buttons;

	public void RefreshDisplay (){
		RemoveButtons ();
		AddButtons ();
	}

	private void RemoveButtons()
	{
		buttons.Clear ();
		for (int i = 0; i < contentPanel.transform.childCount; i++) {
			GameObject.Destroy (contentPanel.GetChild (i).gameObject);
		}
	}

	private void AddButtons()
	{
		List<ObjectStats> liste = PlayerState.Instance.savedObjectStats;
		for (int i = 0; i < liste.Count; i++) 
		{
			ObjectStats objectAux = liste [i];

			GameObject newButton = (GameObject)GameObject.Instantiate(prefab);
			newButton.transform.SetParent(contentPanel);
			newButton.SetActive(true);

			ObjectButtonController objectButton = newButton.GetComponent<ObjectButtonController> ();
			if (buttons.Count == 0) {
				objectButton.selected = true;
			}
			objectButton.Setup (objectAux);
			buttons.Add (objectButton);
		}
	}
}
