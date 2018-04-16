using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectButtonController : MonoBehaviour {
	//Si está seleccionado
	public bool selected = false;
	//Boton guardado como imagen para poder guardar colores (seleccionado y no seleccionado)
	public Image ImageButtom;
	public Color[] colors;
	//Texto que tendrá el botón
	public Text textObject;
	//Objeto en cuestión
	ObjectStats objectStats;

	// Inicializamos la imagen y los colores
	void Start () {
		ImageButtom = GetComponent<Image> ();
		ImageButtom.color = colors [0];
	}

	void FixedUpdate () {
		if (selected) {
			ImageButtom.color = colors [1];
			if (Input.GetKeyDown (KeyCode.Z)) {
				GameObject scrollObject = GameObject.Find ("SubmenuObjetos");
				if (objectStats.typeObject == TypeObject.HealPM || objectStats.typeObject == TypeObject.HealVT) {
					GameObject selectorObject = scrollObject.transform.Find ("SelectorApliObjeto").gameObject;
					selectorObject.GetComponent<CheckSelectorPjObjeto> ().objectStats = objectStats;
					selectorObject.SetActive (true);
				} else {
				}
				scrollObject.GetComponent<MenuObjectController> ().enabled = false;
				this.enabled = false;
				scrollObject.transform.Find ("SelectorApliObjeto").gameObject.GetComponent<ObjectMenuSelectorController> ().selectedButton = this;

			}
			//Si pulsamos X volveremos al menú anterior
			if (Input.GetKeyDown (KeyCode.X)) {
				GameObject objectMenu = GameObject.Find ("SubmenuObjetos");
				objectMenu.GetComponent<MenuObjectController> ().position = new Vector2 (0, 0);
				objectMenu.SetActive (false);
				//No buscamos directamente el menú anterior porque solo podemos buscar GameObjects activos
				GameObject.Find ("MenuJugador").transform.GetChild (0).GetChild (0).gameObject.SetActive (true);
				//Deseleccionamos el botón
				this.selected = false;
			}
		} else {
			ImageButtom.color = colors [0];
		}
	}
	//Le damos el texto adecuado al botón
	public void Setup (ObjectStats object1){
		textObject.text = object1.nameObject + "\tx" + object1.num;
		if (object1.typeObject == TypeObject.Damage) {
			textObject.color = Color.gray;
		}
		objectStats = object1;
	}
}
