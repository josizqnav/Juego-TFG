using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtomController : MonoBehaviour {
	//Si está seleccionado
	public bool selected = false;
	//Boton guardado como imagen para poder guardar colores (seleccionado y no seleccionado)
	public Image ImageButtom;
	public Color[] colors;
	//Nombre del botón
	public string nameButtom;
	public GameObject actualMenu;
	public GameObject nextMenu;

	// Inicializamos la imagen y los colores
	void Start () {
		ImageButtom = GetComponent<Image> ();
		ImageButtom.color = colors [0];

	}

	void FixedUpdate () {
		//Si esta seleccionado cambia el color del botón
		if (selected) {
			ImageButtom.color = colors [1];
			//ImageButtom.sprite = sprites [1];
			//Si elegimos Nuevo juego, iniciamos la siguiente escena
			if (Input.GetKeyDown (KeyCode.Z) && nameButtom=="NuevoJuego") {
				SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex +1);
			}
			//Cambiamos de menú según los siguientes botones
			if (Input.GetKeyDown (KeyCode.Z) && (nameButtom=="CambiarMenu" || nameButtom=="Guardar")) {
				actualMenu.SetActive (false);
				nextMenu.SetActive(true);
			}
			//Si elegimos Salir, saldremos del juego
			if (Input.GetKeyDown (KeyCode.Z) && nameButtom=="Salir") {
				Debug.Log ("Salir del juego");
				Application.Quit ();
			}
			if ((Input.GetKeyDown (KeyCode.Z) || Input.GetKeyDown (KeyCode.X)) && nameButtom=="VolverJuego") {
				actualMenu.SetActive (false);
				nextMenu.GetComponent<Animator> ().enabled = true;
				nextMenu.GetComponent<PlayerController> ().enabled = true;
			}
			if (Input.GetKeyDown (KeyCode.Z) && nameButtom=="VolverMenuP") {
				actualMenu.SetActive (false);
				nextMenu.SetActive(true);
			}
			//Cuando pulsemos x, se volverá al menú anterior en algunos casos.
			if (Input.GetKeyDown (KeyCode.X)) {
				if (nameButtom == "Cargar1" || nameButtom == "Cargar2" || nameButtom == "Cargar3"
				   || nameButtom == "Guardar1" || nameButtom == "Guardar2" || nameButtom == "Guardar3"
				   || nameButtom == "VolverMenuP") {
					actualMenu.SetActive (false);
					nextMenu.SetActive (true);
				}
				if (nameButtom=="Condicion" || nameButtom=="Guardar"
					|| nameButtom=="Equipo" || nameButtom=="Objetos" || nameButtom=="Magia" ) {
					//Accedemos al padre del padre del padre: SubmenúComandos<MenuRaiz < Panel< MenuJugador. Y desactivamos menú
					actualMenu.transform.parent.parent.parent.gameObject.SetActive (false);
					//Reactivamos al jugador.
					PlayerState.Instance.GetComponent<Animator> ().enabled = true;
					PlayerState.Instance.GetComponent<PlayerController> ().enabled = true;
				}
			}//Distintas ranuras para cargar la partida
			if (Input.GetKeyDown (KeyCode.Z) && nameButtom=="Cargar1") {
				GlobalControl.Instance.loadGame("Saves/gamesave1.save");
			}
			if (Input.GetKeyDown (KeyCode.Z) && nameButtom=="Cargar2") {
				GlobalControl.Instance.loadGame("Saves/gamesave2.save");
			}
			if (Input.GetKeyDown (KeyCode.Z) && nameButtom=="Cargar3") {
				GlobalControl.Instance.loadGame("Saves/gamesave3.save");
			}//Distintas ranuras para guardar la partida
			if (Input.GetKeyDown (KeyCode.Z) && nameButtom=="Guardar1") {
				GlobalControl.Instance.saveGame("Saves/gamesave1.save");
			}
			if (Input.GetKeyDown (KeyCode.Z) && nameButtom=="Guardar2") {
				GlobalControl.Instance.saveGame("Saves/gamesave2.save");
			}
			if (Input.GetKeyDown (KeyCode.Z) && nameButtom=="Guardar3") {
				GlobalControl.Instance.saveGame("Saves/gamesave3.save");
			}
			//Si elegimos condición
			if (Input.GetKeyDown (KeyCode.Z) && nameButtom == "Condicion") {
				//Deseleccionamos el botón y desactivamos el menú
				actualMenu.transform.Find("BotonCondicion").gameObject.SetActive(false);
				actualMenu.GetComponent<MainMenuController> ().enabled = false;
				//Activamos el menu selector de pjs y lo ponemos en modo condicion
				MainMenuControllerPlus menu = nextMenu.GetComponent<MainMenuControllerPlus> ();
				menu.enabled = true;
				menu.isCondition = true;
				menu.position = 0;
				//Ponemos como seleccionado el primer botón
				GameObject.Find ("BotonPersonaje1").GetComponent<ButtomController>().selected = true;
			}
			//Si elegimos magia
			if (Input.GetKeyDown (KeyCode.Z) && nameButtom == "Magia") {
				//Deseleccionamos el botón y dejamos por defecto seleccionado condicion, desactivamos el menú
				actualMenu.transform.Find("BotonMagia").gameObject.GetComponent<ButtomController>().selected = false;
				actualMenu.GetComponent<MainMenuController> ().position = 0;
				GameObject buttonCondition = GameObject.Find ("BotonCondicion"); 
				buttonCondition.GetComponent<ButtomController> ().selected = true;
				buttonCondition.SetActive (false);
				actualMenu.GetComponent<MainMenuController> ().enabled = false;
				//Activamos el menu selector de pjs y lo ponemos en modo condicion
				MainMenuControllerPlus menu = nextMenu.GetComponent<MainMenuControllerPlus> ();
				menu.enabled = true;
				menu.isMagic = true;
				menu.position = 0;
				//Ponemos como seleccionado el primer botón
				GameObject.Find ("BotonPersonaje1").GetComponent<ButtomController>().selected = true;
			}
			//Si elegimos equipo
			if (Input.GetKeyDown (KeyCode.Z) && nameButtom == "Equipo") {
				//Deseleccionamos el botón y dejamos por defecto seleccionado condicion, desactivamos el menú
				actualMenu.transform.Find("BotonEquipo").gameObject.GetComponent<ButtomController>().selected = false;
				actualMenu.GetComponent<MainMenuController> ().position = 0;
				GameObject buttonCondition = GameObject.Find ("BotonCondicion"); 
				buttonCondition.GetComponent<ButtomController> ().selected = true;
				buttonCondition.SetActive (false);
				actualMenu.GetComponent<MainMenuController> ().enabled = false;
				//Activamos el menu selector de pjs y lo ponemos en modo condicion
				MainMenuControllerPlus menu = nextMenu.GetComponent<MainMenuControllerPlus> ();
				menu.enabled = true;
				menu.isEquipment = true;
				menu.position = 0;
				//Ponemos como seleccionado el primer botón
				GameObject.Find ("BotonPersonaje1").GetComponent<ButtomController>().selected = true;
			}
			//Si elegimos Arma
			if (Input.GetKeyDown (KeyCode.Z) && nameButtom == "Arma") {
				//Deseleccionamos el botón y desactivamos el menú
				actualMenu.transform.Find("BotonArma").gameObject.GetComponent<ButtomController>().selected = false;
				actualMenu.GetComponent<MainMenuController> ().enabled = false;
				//Creamos los botones
				CheckScrollEquipment checkScrollEquipment = nextMenu.transform.GetChild(0).GetChild(0).gameObject.GetComponent<CheckScrollEquipment>();
				checkScrollEquipment.RefreshWeapons ();
				if (checkScrollEquipment.buttons.Count == 0) {
					GameObject noEquipmentPanel = actualMenu.transform.Find ("AvisoNoEquipamiento").gameObject;
					noEquipmentPanel.SetActive (true);
					noEquipmentPanel.GetComponent<NoEquipmentController> ().isWeapon = true;
				} else {
					//Activamos el menu selector
					nextMenu.SetActive(true);
				}
			}
			//Si elegimos Armadura
			if (Input.GetKeyDown (KeyCode.Z) && nameButtom == "Armadura") {
				//Deseleccionamos el botón y desactivamos el menú
				actualMenu.transform.Find("BotonArmadura").gameObject.GetComponent<ButtomController>().selected = false;
				actualMenu.GetComponent<MainMenuController> ().enabled = false;
				//Creamos los botones
				CheckScrollEquipment checkScrollEquipment = nextMenu.transform.GetChild(0).GetChild(0).gameObject.GetComponent<CheckScrollEquipment>();
				checkScrollEquipment.RefreshArmors ();
				if (checkScrollEquipment.buttons.Count == 0) {
					GameObject noEquipmentPanel = actualMenu.transform.Find ("AvisoNoEquipamiento").gameObject;
					noEquipmentPanel.SetActive (true);
					noEquipmentPanel.GetComponent<NoEquipmentController> ().isWeapon = false;
				} else {
					//Activamos el menu selector
					nextMenu.SetActive(true);
				}
			}
			//Si pulsamos X en el Submenú Equipo
			if (Input.GetKeyDown (KeyCode.X) && (nameButtom == "Armadura" || nameButtom == "Arma")) {
				//Desactivamos el submenu equipo al completo
				actualMenu.transform.parent.gameObject.SetActive (false);
				//Activamos el menu raiz
				GameObject.Find ("MenuJugador").transform.GetChild (0).GetChild (0).gameObject.SetActive (true);
			}
			//Si pulsamos X al elegir pj para aplicar magia
			if (Input.GetKeyDown (KeyCode.X) && (nameButtom == "ApliMagiaPj1" || nameButtom == "ApliMagiaPj2")) {
				//Dejamos el selector por defecto
				MagicMenuSelectorController menu1 = actualMenu.GetComponent<MagicMenuSelectorController> ();
				this.selected = false;
				menu1.buttoms [0].selected = true;
				menu1.position = 0;

				actualMenu.SetActive (false);
				nextMenu.GetComponent<MenuMagicController> ().enabled = true;
				menu1.buttonSelected.enabled = true;
			}
		} else {
			ImageButtom.color = colors [0];
		}
			
	}
}
