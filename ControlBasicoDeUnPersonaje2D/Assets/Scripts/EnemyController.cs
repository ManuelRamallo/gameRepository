using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {


    public float speed = 1f;
    public float maxSpeed = 1f;

    private Rigidbody2D rb2b;
    // Use this for initialization
    void Start () {
        rb2b = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        rb2b.AddForce(Vector2.right * speed);

        //Con esta funcion matematica le decimos las velocidades que queremos para poder limitarlas
        float limitedSpeed = Mathf.Clamp(rb2b.velocity.x, -maxSpeed, maxSpeed);
        rb2b.velocity = new Vector2(limitedSpeed, rb2b.velocity.y);

        //Haremos esto para que el enemigo sepa cuando tiene que cambiar de sentido en el movimiento
        if(rb2b.velocity.x > -0.01f && rb2b.velocity.x < 0.01f){
            speed = -speed;
            rb2b.velocity = new Vector2(speed, rb2b.velocity.y);
        }

        if(speed > 0){
            GetComponent<SpriteRenderer>().flipX = true;
        }else if(speed < 0){
            GetComponent<SpriteRenderer>().flipX = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D col) {
        if(col.gameObject.tag == "Player"){
            Debug.Log("Player detected!");

            float yOffset = 1.05f;
            if(transform.position.y + yOffset < col.transform.position.y){
                col.SendMessage("EnemyJump");
                Destroy(gameObject);
            } else {
                col.SendMessage("EnemyNockBack", transform.position.x);
            }
           
        }
    }

}
