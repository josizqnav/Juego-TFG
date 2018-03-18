using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MagicButtonController : MonoBehaviour {
	//Si está seleccionado
	public bool selected = false;
	//Boton guardado como imagen para poder guardar colores (seleccionado y no seleccionado)
	public Image ImageButtom;
	public Color[] colors;
	//Texto que tendrá el botón
	public Text textMagic;
	//Guardará los Stats del equipamiento
	public MagicStats magicStats;

	// Inicializamos la imagen y los colores
	void Start () {
		ImageButtom = GetComponent<Image> ();
		ImageButtom.color = colors [0];
	}
	

	void FixedUpdate () {
		if (selected) {
			ImageButtom.color = colors [1];
			if (Input.GetKeyDown (KeyCode.Z)) {
				GameObject scroollMagic = GameObject.Find ("ScrollMagia");
				if (magicStats.typeMagic == TypeMagic.Heal && PlayerState.Instance.savedPlayerStats.actualMagicPoints >= magicStats.expensePM) {
					GameObject selectorMagic = scroollMagic.transform.Find ("SelectorApliMagia").gameObject;
					selectorMagic.SetActive (true);
					selectorMagic.GetComponent<MagicMenuSelectorController> ().magic = magicStats;
					selectorMagic.GetComponent<MagicMenuSelectorController> ().buttonSelected = this;
					scroollMagic.GetComponent<MenuMagicController> ().enabled = false;
					this.enabled = false;
				} else {
					GameObject panel = scroollMagic.transform.Find ("AvisoNoMagia").gameObject;
					panel.SetActive (true);
					panel.GetComponent<NoMagicController> ().button = this;
					scroollMagic.GetComponent<MenuMagicController>().enabled = false;
					this.enabled = false;
				}
			}
			//Si pulsamos X volveremos al menú anterior
			if (Input.GetKeyDown (KeyCode.X)) {
				GameObject magicMenu = GameObject.Find ("SubmenuMagia");
				magicMenu.transform.Find ("ScrollMagia").gameObject.GetComponent<MenuMagicController> ().position.Set (0, 0);
				magicMenu.SetActive (false);
				//No buscamos directamente el menú anterior porque solo podemos buscar GameObjects activos
				GameObject.Find ("MenuJugador").transform.GetChild (0).GetChild (0).gameObject.SetActive (true);
			}
		} else {
			ImageButtom.color = colors [0];
		}
	}

	//Le damos el texto adecuado al botón
	public void SetupMagic (MagicStats magic){
		textMagic.text = magic.nameObject;
		if (magic.typeMagic == TypeMagic.Damage) {
			textMagic.color = Color.gray;
		}
		magicStats = magic;
	}
}
