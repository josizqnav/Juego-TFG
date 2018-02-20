using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour {
		//Lista de botones del menú
		public ButtomController[] buttoms;
		//Posición que indica el botón seleccionado
		public int position = 0;

		void Update(){
			//Cuando pulsemos la tecla flecha abajo
			if (Input.GetKeyDown (KeyCode.DownArrow)) {
				//Deseleccionamos el botón actual y sumamos una posición (bajamos)
				buttoms [position].selected = false;
				position++;
				//Si nos encontramos en la primera posición (0) no podemos subir más
					if (position < 0) {
						position = 0;
						buttoms [position].selected = true;
						return;
					}
				//Si nos econtramos en la última posición (longitud del array) no podemos bajar más
					if (position > buttoms.Length - 1) {
						position = buttoms.Length - 1;
						buttoms [position].selected = true;
						return;
					}
				//Marcamos como seleccionado el siguiente botón
				buttoms [position].selected = true;
			}
			//Si pulsamos la tecla flecha arriba, se hará lo mismo pero restando posición
			if (Input.GetKeyDown (KeyCode.UpArrow)) {
				buttoms [position].selected = false;
				position--;
				if (position < 0) {
					position = 0;
					buttoms [position].selected = true;
					return;
				}
				if (position > buttoms.Length - 1) {
					position = buttoms.Length - 1;
					buttoms [position].selected = true;
					return;
				}
				buttoms [position].selected = true;
			}
		}
}
