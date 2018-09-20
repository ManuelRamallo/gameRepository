using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaFalling : MonoBehaviour {


    public float fallDelay = 1f;
    public float respawnDelay = 5f;


    private Rigidbody2D rb2d;

    //Esto gestiona la colision
    private EdgeCollider2D ec2d;

    private Vector3 start;

	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        ec2d = GetComponent<EdgeCollider2D>();
        start = transform.position;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D col) {
        if(col.gameObject.CompareTag("Player")){
            //esto sirve para invocar un metod y darle un tiempo de delay
            Invoke("Fall", fallDelay);
            Invoke("Respawn", fallDelay + respawnDelay);
        }
    }


    //Este metod hace que el objeto tenga un rigidbody con gravedad (pero en este caso necesita que ocurra algo antes) (como por ejemplo que el personaje se coloque
    //encima de la plataforma
    //Ademas le ponemos el trigger para que una vez el player toque la plataforma esta no pueda colisionar con mas nada de la escena
    void Fall(){
        rb2d.isKinematic = false;
        //esto desactiva temporalmente la colision del elemento, para que no pueda tocar nada
        ec2d.isTrigger = true;
    }

    //Este metod sirve para volver a respawnear la plataforma en el lugar que estaba al principio
    void Respawn(){
        transform.position = start;
        ec2d.isTrigger = false;
        //Estas dos lineas hacen que la plataforma una vez haga respawn vuelva a tener un rigidbody dependiente de un objeto que se coloque encima suya y además
        //le quitamos la velocidad para que no se mueva del sitio y se quede donde estaba al principio 
        rb2d.isKinematic = true;
        rb2d.velocity = Vector3.zero;

    }

}
