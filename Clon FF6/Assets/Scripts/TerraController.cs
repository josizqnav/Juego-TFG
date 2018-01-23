using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class TerraController : MonoBehaviour {

	public float speed = 4f;
	Animator anim;
	Rigidbody2D rb2d;
	Vector2 mov;
	public GameObject initialMap;

	void Awake (){
		Assert.IsNotNull (initialMap);
	}

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		rb2d = GetComponent<Rigidbody2D> ();

		Camera.main.GetComponent<MainCamera>().SetBound(initialMap);
	}
	
	// Update is called once per frame
	void Update () {
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
		rb2d.MovePosition (rb2d.position + mov * speed * Time.deltaTime);
	}
}
