using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class PlayerController : MonoBehaviour {
	//Velocidad de movimiento
	public float speed = 4f;

	Animator anim;
	Rigidbody2D rb2d;
	Vector2 mov;
	//Mapa donde comienza la escena
	public GameObject initialMap;

	void Awake (){
		Assert.IsNotNull (initialMap);
	}

	void Start () {
		anim = GetComponent<Animator> ();
		rb2d = GetComponent<Rigidbody2D> ();
		//Se establecen los límites de la cámara
		Camera.main.GetComponent<MainCamera>().SetBound(initialMap);
	}

	void Update () {
		//Se detecta el movimiento en el vector 2D creado
		mov = new Vector2 (Input.GetAxisRaw ("Horizontal"),
			Input.GetAxisRaw ("Vertical"));

		if (mov != Vector2.zero) {
			anim.SetFloat ("movX", mov.x);
			anim.SetFloat ("movY", mov.y);
			anim.SetBool ("andando", true);
		} else {
			anim.SetBool ("andando", false);
		}

	}

	void FixedUpdate () {
		//Se actualiza la posición al moverse
		rb2d.MovePosition (rb2d.position + mov * speed * Time.deltaTime);
	}
}
