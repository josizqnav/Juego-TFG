using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckScrollObjects : MonoBehaviour {
	//Contenido del Scroll
	public Transform contentPanel;
	//Grupo de objetos
	public SimpleObjectPool buttonObjectPool;
	//Array de botones
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
		//Obtenemos el número de objetos y le damos dimensión al array de botones
		int aux = PlayerState.Instance.savedObjectStats.Count;
		buttons = new ObjectButtonController[aux];
		for (int i = 0; i < aux; i++) 
		{
			//Creamos el nuevo botón y lo añadimos al contenido del scroll
			ObjectStats object2 = PlayerState.Instance.savedObjectStats[i];
			GameObject newButton = buttonObjectPool.GetObject();
			newButton.transform.SetParent(contentPanel);

			ObjectButtonController objectButton = newButton.GetComponent<ObjectButtonController>();
			//Si es el primer elemento lo seleccionamos
			if (i == 0) {
				objectButton.selected = true;
			}
			//Le cambiamos el texto y lo añadimos a la lista de botones
			objectButton.Setup(object2);
			buttons [i] = objectButton;
		}
	}
}
