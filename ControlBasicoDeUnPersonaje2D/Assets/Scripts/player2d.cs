using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player2d : MonoBehaviour {

    public float speed = 2f;
    public float maxSpeed = 5f;
    public bool grounded;
    public float jumpPower = 8f;
    public float heal = 2f;

    private Rigidbody2D rb2b;
    private Animator anim;
    private SpriteRenderer spr;
    private bool jump;
    private bool doubleJump;
    private bool movement = true;
    private Color color;
    private GameObject healt;


    private float contador = 0f;
    

	
	void Start () {
        rb2b = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spr = GetComponent<SpriteRenderer>();

        healt = GameObject.Find("Hearts");
    }
	

	void Update () {
        anim.SetFloat("Correr", Mathf.Abs(rb2b.velocity.x));
        anim.SetBool("TocandoSuelo", grounded);

        //esto permite el salto de precaucion, si estamos cayendo podemos hacer un salto para poder volver a incorporarnos
        if(grounded){
            doubleJump = true;
        }

        //con el double jump podemos realizar un doble salto tal como lo tenemos, sin double jump no hace falta el else if y solo tenedremos un salto normal. 
        if(Input.GetKeyDown(KeyCode.W)){
            if (grounded){
                jump = true;
                doubleJump = true;
            } else if(doubleJump){
                jump = true;
                doubleJump = false;
            }

        }

    }


    //es como el update pero no genera errores, es bueno para los movimientos de los personajes y las colisiones
    void FixedUpdate(){

        Vector3 fixedVelocity = rb2b.velocity;
        fixedVelocity.x *= 0.75f;

        if(grounded){
            rb2b.velocity = fixedVelocity;
        }

        float h = Input.GetAxis("Horizontal");
        if(!movement){
            h = 0;
        }

        rb2b.AddForce(Vector2.right *  speed * h);

        //Con esta funcion matematica le decimos las velocidades que queremos para poder limitarlas
        float limitedSpeed = Mathf.Clamp(rb2b.velocity.x, -maxSpeed, maxSpeed);
        rb2b.velocity = new Vector2(limitedSpeed, rb2b.velocity.y);


        //Con esto comprobamos si hay alguna velocidad y que nos estamos moviendo a la derecha (mayor que) o a la izquierda (menor que) para girar el personaje
        if(h > 0.1f){
            GetComponent<SpriteRenderer>().flipX = false;
        }

        if(h < -0.1f){
            GetComponent<SpriteRenderer>().flipX = true;
        }

        if(jump){
            rb2b.velocity = new Vector2(rb2b.velocity.x, 0f);
            rb2b.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            jump = false;
        }

        //Debug.Log(rb2b.velocity.x);

    }

    //metod para hacer respawn del personaje en una posicion indicada
    private void OnBecameInvisible(){
        Debug.Log("Entra aquí cada vez que el personaje hace respawn");
        //transform.position = new Vector3(-7.162f, -0.408f, 0f);
        //heal = 2f;

        //esta linea te recarga la scene
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //Destroy(gameObject);
        

        //RestartGame();
        

    }


    public void EnemyJump(){
        jump = true;
    }

    public void EnemyNockBack(float enemyPosX){

        contador += 1;
        healt.SendMessage("TakeDamage", contador);

        jump = true;

        float side = Mathf.Sign(enemyPosX - transform.position.x);
        rb2b.AddForce(Vector2.left * side * jumpPower, ForceMode2D.Impulse);

        movement = false;
        Invoke("EnableMovement", 0.7f);
        Invoke("EnemyHit", 0f);

        //con esta comparacion el personaje muere al llegar la vida a 0
        if(heal.Equals(0f)){
            Invoke("OnBecameInvisible", 0.8f);
        }


        //ESTO ES UNA FORMA DE OBTENER EL COLOR SOLO ESCRIBIENDO EL CODIGO HTML Y CON UN IF
        //if(ColorUtility.TryParseHtmlString("#801818", out color)) { 
        //spr.color = color; }

        //ESTO ES OTRA FORMA DE OBTENER EL COLOR QUE QUERAMOS
        //ASI PODEMOS OBTENER LOS COMO RGB Y SI LO DIVIDIMOS ENTRE 255 NO TENDREMOS QUE HACER EL CALCULO PREVIO DE CABEZA (OBTENDREMOS EL MISMO COLOR)
        Color color = new Color(217/255f, 62/255f, 62/255f);
        spr.color = color;

    }

    void EnableMovement(){
        movement = true;
        spr.color = Color.white;
    }

    void EnemyHit(){
        heal = heal -1;
    }



    //public void RestartGame(){
    //    SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
    //}


    //así le podemos dar una velocidad para que vaya a la derecha y a la izquierda (dependiendo si etá en positivo o negativo)
    //if(rb2b.velocity.x > maxSpeed){
    //    rb2b.velocity = new Vector2(maxSpeed, rb2b.velocity.y);
    //}

    //if (rb2b.velocity.x < -maxSpeed)
    //{
    //    rb2b.velocity = new Vector2(-maxSpeed, rb2b.velocity.y);
    //}


    //TODO esto es como lo hacía l_draven, es un modo muy basico, lo de arriba es algo mas avanzado

    //if (Input.GetKey(KeyCode.D))
    //{
    //    if (GetComponent<SpriteRenderer>().flipX)
    //    {
    //        GetComponent<SpriteRenderer>().flipX = false;
    //    }
    //    GetComponent<Animator>().SetBool("Correr", true);
    //    transform.Translate(0.08f, 0, 0);
    //}



    //if (Input.GetKey(KeyCode.A))
    //{
    //    if (!GetComponent<SpriteRenderer>().flipX)
    //    {
    //        GetComponent<SpriteRenderer>().flipX = true;
    //    }
    //    GetComponent<Animator>().SetBool("Correr", true);
    //    transform.Translate(-0.08f, 0, 0);
    //}



    //if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A))
    //{
    //    GetComponent<Animator>().SetBool("Correr", false);
    //}
}
