using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float speed =  4f;

    Animator anim;
    Vector2 mov; //Ahora es visible entre metods
    Rigidbody2D rb2d;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {

        mov = new Vector2(
            Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical"));




        //transform.position = Vector3.MoveTowards(
        //    transform.position,
        //    transform.position + movimiento,
        //    speed * Time.deltaTime);

        if(mov != Vector2.zero) {
            anim.SetFloat("MoveX", mov.x);
            anim.SetFloat("MoveY", mov.y);
            anim.SetBool("walking", true);
        } else {
            anim.SetBool("walking", false);
        }

	}


    private void FixedUpdate() {
        rb2d.MovePosition(rb2d.position + mov * speed * Time.deltaTime);
    }

}
