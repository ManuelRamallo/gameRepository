using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float speed =  4f;

    Animator anim;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

        Vector3 movimiento = new Vector3(
            Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical"),
            0);

        transform.position = Vector3.MoveTowards(
            transform.position,
            transform.position + movimiento,
            speed * Time.deltaTime);

        anim.SetFloat("MoveX", movimiento.x);
        anim.SetFloat("MoveY", movimiento.y);


	}
}
