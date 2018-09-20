using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCamera : MonoBehaviour {

    public Camera fpsCamera;

    public float horizontalSpped;
    public float verticalSpeed;

    float horizontal;
    float vertical;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        horizontal = horizontalSpped * Input.GetAxis("Mouse X");
        vertical =  verticalSpeed * Input.GetAxis("Mouse Y");

        transform.Rotate(0, horizontal, 0);
        fpsCamera.transform.Rotate(-vertical, 0, 0);


        if (Input.GetKey(KeyCode.W))
        {

            transform.Translate(0, 0, 0.1f);

        }
        else if (Input.GetKey(KeyCode.S))
        {

            transform.Translate(0, 0, -0.1f);

        }
        else if (Input.GetKey(KeyCode.D))
        {

            transform.Translate(0.1f, 0, 0);

        }else if (Input.GetKey(KeyCode.A)){

            transform.Translate(-0.1f, 0, 0);

        }else if(Input.GetKey(KeyCode.Space)){

            transform.Translate(0, 0.1f, 0);

        }
	}
}
