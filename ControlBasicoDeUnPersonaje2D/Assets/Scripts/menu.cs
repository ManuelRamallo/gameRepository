using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour {


    public GameObject flecha, lista;

    int index = 0;

	// Use this for initialization
	void Start () {
        Dibujar();
	}
	
	// Update is called once per frame
	void Update () {

        bool up = Input.GetKeyDown("up");
        bool down = Input.GetKeyDown("down");

        if(up) index--;
        if(down) index++;

        if(index > lista.transform.childCount -1){
            index = 0;
        } else if(index < 0){
            index = lista.transform.childCount - 1;
        }


        if(up || down) { Dibujar(); }

        if(Input.GetKeyDown("return")){
            Accion();
        }

	}

    public void Dibujar(){
        Transform opcion = lista.transform.GetChild(index);
        flecha.transform.position = opcion.position;
    }

    public void Accion(){
        //con esto sabemos a que opcion estamos haciendo referencia
        Transform opcion = lista.transform.GetChild(index);

        if(opcion.gameObject.name == "Salir"){
            print("Cerrando juego...");
            //Con esta linea podremos salir del juego y quitarlo totalmente.
            Application.Quit();
        }else if(opcion.gameObject.name == "Nuevo"){
            //Con esto cargamos la escena que queramos
            //la parte de opcion.gameObject.name haremos referencia a ambas cosas, el nombre que le hemos dado a la opcion y a la escena si la llamamos igual
            // para poder hacer eso tendremos que poner el mismo nombre a la escena de la opción
            SceneManager.LoadScene("Juego 2D");
        }


    }

}
