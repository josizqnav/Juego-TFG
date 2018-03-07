using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuObjectController : MonoBehaviour {
	public CheckScrollObjects checkScrollObjects;
	public ObjectButtonController[] buttons;
	public Vector2 position = new Vector2(0, 0);

	//Para controlar la barra
	public Scrollbar scrollRect;

	void Update () {
		buttons = checkScrollObjects.buttons;
		int positionAux = 0;
		bool limit = false;
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
			limit = checkLimits (positionAux);
			//Seleccionamos el nuevo menú
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
			limit = checkLimits (positionAux);
			//Seleccionamos el nuevo menú
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
			limit = checkLimits (positionAux);
			//Seleccionamos el nuevo menú
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
			limit = checkLimits (positionAux);
			//Seleccionamos el nuevo menú
			if (!limit) {
				positionAux--;
				buttons [positionAux].selected = true;
			}
		}
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

	private void controlScroll(){
		float itemtotal = Mathf.Round ((buttons.Length - 1) / 2);
		scrollRect.value = 1.0f - (position.y / itemtotal);
	}
		
}
