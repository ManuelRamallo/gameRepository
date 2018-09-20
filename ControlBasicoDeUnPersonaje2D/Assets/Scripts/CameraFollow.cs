using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    //le damos el objeto que tiene que seguir (en este caso será el personaje)
    public GameObject follow;

    public Vector2 minCamPos, maxCamPos;

    public float smoothTime;

    private Vector2 velocity;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        //Obtenemos la posicion X y la posicion Y del objeto y lo guardamos en las variables
        float posX = Mathf.SmoothDamp(transform.position.x,
                                      follow.transform.position.x, ref velocity.x, smoothTime);

        //el smoothDamp lo que hace es, suavizar desde una posicion X o Y hasta otra posicion X o Y, que lo gestione con la variable de velocidad en un periodo de tiempo
        //(smoothTime)
        float posY = Mathf.SmoothDamp(transform.position.y,
                                      follow.transform.position.y, ref velocity.y, smoothTime);

        //Le damos la posicion del objeto a la camara para que se vaya moviendo segun la posicion del personaje
        transform.position = new Vector3(
            Mathf.Clamp(posX, minCamPos.x, maxCamPos.x),
            Mathf.Clamp(posY, minCamPos.y, maxCamPos.y),
            transform.position.z);
	}
}
