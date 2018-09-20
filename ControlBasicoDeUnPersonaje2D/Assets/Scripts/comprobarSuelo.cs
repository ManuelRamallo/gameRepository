using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class comprobarSuelo : MonoBehaviour {


    private player2d player;
    private Rigidbody2D rb2d;

	// Use this for initialization
	void Start () {
        player = GetComponentInParent<player2d>();
        rb2d = GetComponentInParent<Rigidbody2D>();
	}

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Platform"){
            rb2d.velocity = new Vector3(0f, 0f, 0f);

            //hacemos al personaje hijo de la plataforma para que se mueva con la plataforma y puedas saltar cuando sube y eso
            player.transform.parent = col.transform;


            player.grounded = true;
        }
    }

    void OnCollisionStay2D(Collision2D col){
        if (col.gameObject.tag == "Ground"){
            player.grounded = true;
        }

        if(col.gameObject.tag == "Platform"){
            player.transform.parent = col.transform;
            player.grounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D col){
        if (col.gameObject.tag == "Ground"){
            player.grounded = false;
        }

        if (col.gameObject.tag == "Platform")
        {
            player.transform.parent = null;
            player.grounded = false;
        }

    }


}
