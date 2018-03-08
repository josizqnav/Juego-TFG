using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuObjectController : MonoBehaviour {
	//Lista de objetos y botones a crear
	public CheckScrollObjects checkScrollObjects;
	public ObjectButtonController[] buttons;
	//Vector que hará de matriz 2D para obtener la posición de los botones
	public Vector2 position = new Vector2(0, 0);

	//Para controlar la barra
	public Scrollbar scrollRect;
	//Texto con la descripción del objeto
	public Text textDescription;

	void Update () {
		//Añadimos los botones a la lista
		buttons = checkScrollObjects.buttons;
		//Marcará la posición del botón en la lista
		int positionAux = 0;
		//Nos indicará si pasamos los límites de la lista o no
		bool limit = false;
		//Se obtendrá la posición en la lista a través de la matriz dependiendo si está en la columna 0 o 1
		if (position.x == 0) {
			positionAux = (int) position.y * 2;
		} else {
			positionAux = (int) (position.y * 2) + 1;
		}
		//Cuando pulsemos la tecla flecha abajo
		if (Input.GetKeyDown (KeyCode.DownArrow)) {
			//Deseleccionamos el botón actual y actualizamos posición
			buttons [positionAux].selected = false;
			position.y++;
			//Comprobamos si traspasa los limites
			limit = checkLimits (positionAux);
			//Si no los traspasa seleccionamos el nuevo botón
			if (!limit) {
				positionAux = positionAux + 2;
				buttons [positionAux].selected = true;
			}
		}
		//Cuando pulsamos la flecha arriba
		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			//Deseleccionamos el botón actual y actualizamos posición
			buttons [positionAux].selected = false;
			position.y--;
			//Comprobamos si traspasa los limites
			limit = checkLimits (positionAux);
			//Si no los traspasa seleccionamos el nuevo botón
			if (!limit) {
				positionAux = positionAux - 2;
				buttons [positionAux].selected = true;
			}
		}
		//Cuando pulsamos la flecha derecha
		if (Input.GetKeyDown (KeyCode.RightArrow)) {
			//Deseleccionamos el botón actual y actualizamos posición
			buttons [positionAux].selected = false;
			position.x++;
			//Comprobamos si traspasa los limites
			limit = checkLimits (positionAux);
			//Si no los traspasa seleccionamos el nuevo botón
			if (!limit) {
				positionAux++;
				buttons [positionAux].selected = true;
			}
		}
		//Cuando pulsamos la flecha izquierda
		if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			//Deseleccionamos el botón actual y actualizamos posición
			buttons [positionAux].selected = false;
			position.x--;
			//Comprobamos si traspasa los limites
			limit = checkLimits (positionAux);
			//Si no los traspasa seleccionamos el nuevo botón
			if (!limit) {
				positionAux--;
				buttons [positionAux].selected = true;
			}
		}
		//Actualizamos la descripción del nuevo objeto seleccionado
		textDescription.text = PlayerState.Instance.savedObjectStats [positionAux].description;
		//Actualizamos la posición del scroll
		controlScroll ();
	}

	private bool checkLimits(int positionAux){
		//No podemos subir más
		if (position.y < 0) {
			position.y = 0;
			buttons [positionAux].selected = true;
			return true;
		}
		//No podemos bajar más
		if (position.y > (buttons.Length/2) - 1) {
			position.y = (buttons.Length / 2) - 1;
			buttons [positionAux].selected = true;
			return true;
		}
		//No se puede ir más a la derecha
		if (position.x > 1) {
			position.x = 1;
			buttons [positionAux].selected = true;
			return true;
		}
		//No se puede ir más a la izquierda
		if (position.x < 0) {
			position.x = 0;
			buttons [positionAux].selected = true;
			return true;
		}
		return false;
	}
	//Controlará el movimiento del scroll conforme se baje o suba en la lista
	private void controlScroll(){
		//Obtenemos el valor máximo de Y
		float maxY = Mathf.Round ((buttons.Length - 1) / 2);
		//Actualizamos la posición del scroll
		scrollRect.value = 1.0f - (position.y / maxY);
	}
		
}
