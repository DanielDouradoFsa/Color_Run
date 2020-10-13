using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    public float speed;
    public float jumpHeight;
    public float gravity;
    public float horizontalSpeed;
    private float jumpVelocity;
    private bool isMovingR = false;
    private bool isMovingL = false;
    private bool isJumping = false;
    public float rayRadius;
    public LayerMask layer;
    public Animator anim;
    public bool isDead = false;
    private GameController gc;

    void Start()
    {
        controller = GetComponent<CharacterController> ();
        gc = FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        //foward é o eixo Z para frente
        Vector3 direction = Vector3.forward * speed;
        if(controller.isGrounded){
            if(Input.GetKeyDown(KeyCode.Space)){
                jumpVelocity = jumpHeight;
                isJumping=true; // faz ele pular
            }
        }
        if(Input.GetKeyDown(KeyCode.RightArrow) && !isMovingR && transform.position.x <= 4f){
            if(Input.GetKeyDown(KeyCode.Space)){
                jumpVelocity = jumpHeight;
                isJumping=true; // faz ele pular
            }
            isMovingR = true;
            StartCoroutine(RightMove()); //move para a direita
        }
        if(Input.GetKeyDown(KeyCode.LeftArrow) && !isMovingL && transform.position.x >= -4f){
            if(Input.GetKeyDown(KeyCode.Space)){
                jumpVelocity = jumpHeight; // faz ele pular
            }
            isMovingL = true;
            StartCoroutine(LeftMove()); //move para a esquerda
        } 
        if(!controller.isGrounded){
            jumpVelocity -= gravity; //faz ele cair
        }
        speed += speed*(Time.deltaTime/50); //incrementa velocidade com o tempo
        direction.y= jumpVelocity; //pular
        controller.Move(direction*Time.deltaTime); //mover
        OnCollision();
        if(transform.position.y < -2){
            anim.SetTrigger("die");
            speed = 0;
            jumpHeight = 0;
            horizontalSpeed = 0;
            isDead = true;
            Invoke("GameOver",1f);
           
        }
    }

    //método que é executado várias vezes
    IEnumerator LeftMove(){
        for(float i = 0; i<3; i += 0.1f){
            controller.Move(Vector3.left * Time.deltaTime * horizontalSpeed);
            yield return null;
        }
        isMovingL = false;
    }
    IEnumerator RightMove(){
        for(float i = 0; i<3; i += 0.1f){
            controller.Move(Vector3.right * Time.deltaTime * horizontalSpeed);
            yield return null;
        }
        isMovingR = false;
    }

    void OnCollision(){
        RaycastHit hit; //armazena o objeto que foi batido
        // if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, rayRadius, layer) && !isDead){
        //     Debug.Log("bateu poha");
        //     anim.SetTrigger("die");
        //     speed = 0;
        //     jumpHeight = 0;
        //     horizontalSpeed = 0;
        //     isDead = true;
        //     Invoke("GameOver",1f);
        // }
    }

    void GameOver(){
        gc.ShowGameOver();
    }
}
