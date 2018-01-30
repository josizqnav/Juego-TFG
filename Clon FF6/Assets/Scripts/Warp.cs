using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class Warp : MonoBehaviour
{
    // Almacenamos el punto y mapa destino
    public GameObject target;
	public GameObject targetMap;

	// Variables que controlan la transición: Si empieza, si es de entrada, opacidad y tiempo
	bool startFade = false;
	bool isFadeIn = false;
	float opacity = 0;
	float fadeTime = 1f;

    void Awake ()
    {
        Assert.IsNotNull(target);

        // Escondemos los render del warp
        GetComponent<SpriteRenderer> ().enabled = false;
        transform.GetChild (0).GetComponent<SpriteRenderer> ().enabled = false;

		Assert.IsNotNull (targetMap);
    }

	IEnumerator OnTriggerEnter2D (Collider2D col) {
		//Comenzamos transición y desactivamos el movimiento del jugador
		FadeIn ();
		col.GetComponent<Animator> ().enabled = false;
		col.GetComponent<PlayerController> ().enabled = false;

		//Esperamos el tiempo para que la transición se complete
		yield return new WaitForSeconds (fadeTime);

        // Actualizamos la posición del jugador y la cámara en la nueva zona
        col.transform.position = target.transform.GetChild (0).transform.position;
		Camera.main.GetComponent<MainCamera>().SetBound(targetMap);

		//Deshacemos transición y habilitamos de nuevo al jugador
		FadeOut ();
		col.GetComponent<Animator> ().enabled = true;
		col.GetComponent<PlayerController> ().enabled = true;
    }

	// Método para dibujar un cuadrado negro que sirve de transición
	void OnGUI () {

		if (!startFade)
			return;

		// Creamos color con opacidad a 0
		GUI.color = new Color (GUI.color.r, GUI.color.g, GUI.color.b, opacity);

		// Creamos la textura negra para rellenar la pantalla y la dibujamos en ella
		Texture2D tex;
		tex = new Texture2D (1, 1);
		tex.SetPixel (0, 0, Color.black);
		tex.Apply ();
		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), tex);

		//Cuando aparezca vamos subiendo la opacidad y cuando la deshagamos la vamos bajando hasta que acabe
		if (isFadeIn) {
			opacity = Mathf.Lerp (opacity, 1.1f, fadeTime * Time.deltaTime);
		} else {
			opacity = Mathf.Lerp (opacity, -0.1f, fadeTime * Time.deltaTime);
			if (opacity < 0) startFade = false;
		}

	}

	// Método para activar la transición de entrada
	void FadeIn () {
		startFade = true;
		isFadeIn = true;
	}

	// Método para deshacer transición
	void FadeOut () {
		isFadeIn = false;
	}

}