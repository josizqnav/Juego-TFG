using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckScrollObjects : MonoBehaviour {

	public Transform contentPanel;
	public SimpleObjectPool buttonObjectPool;
	public ObjectButtonController[] buttons;

	// Use this for initialization
	void Start () {
		RefreshDisplay ();
		
	}

	public void RefreshDisplay (){
		RemoveButtons ();
		AddButtons ();
	}

	private void RemoveButtons()
	{
		while (contentPanel.childCount > 0) 
		{
			GameObject toRemove = transform.GetChild(0).gameObject;
			buttonObjectPool.ReturnObject(toRemove);
		}
	}

	private void AddButtons()
	{
		int aux = PlayerState.Instance.savedObjectStats.Count;
		buttons = new ObjectButtonController[aux];
		for (int i = 0; i < aux; i++) 
		{
			ObjectStats object2 = PlayerState.Instance.savedObjectStats[i];
			GameObject newButton = buttonObjectPool.GetObject();
			newButton.transform.SetParent(contentPanel);

			ObjectButtonController objectButton = newButton.GetComponent<ObjectButtonController>();
			if (i == 0) {
				objectButton.selected = true;
			}
			objectButton.Setup(object2);
			buttons [i] = objectButton;
		}
	}
}
