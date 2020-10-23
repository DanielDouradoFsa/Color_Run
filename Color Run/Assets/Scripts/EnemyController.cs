using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private CharacterController controller;
    public PlayerController playerController;
    public float speed;
    public float horizontalSpeed;
    public Animator anim;

    public Transform playerPosition;


    void Start()
    {
        controller = GetComponent<CharacterController> ();
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController> ();
       
    }

    void Update()
    {
        playerPosition = GameObject.FindGameObjectWithTag("Player").transform;
        Debug.Log(playerPosition.position.x);
        speed = -playerController.speed;
        horizontalSpeed = playerController.horizontalSpeed;
        Vector3 direction = Vector3.back * speed;

        /*if(Input.GetKey(KeyCode.RightArrow) && !playerController.isMovingR && transform.position.x <= 4f){
            StartCoroutine(RightMove());//move para a direita 
        }*/
        if(playerPosition.position.x<-2.48 && playerPosition.position.x>-4.79){
            controller.Move(Vector3.left * playerPosition.position.x);
        }
        if(playerPosition.position.x>2.48 && playerPosition.position.x<4.56){
            controller.Move(Vector3.right * playerPosition.position.x);
        }
        /*if(Input.GetKey(KeyCode.LeftArrow) && !playerController.isMovingL && transform.position.x >= -4f){
            StartCoroutine(LeftMove());//move para a esquerda
        }*/ 
        speed += speed*(Time.deltaTime/50); //incrementa velocidade com o tempo
       
        controller.Move(direction*Time.deltaTime); //mover

        if(playerController.isDead){
            speed = 0;
            horizontalSpeed = 0;
        }
    }

    IEnumerator LeftMove(){
        for(float i = 0; i<1; i += 0.1f){
            controller.Move(Vector3.left * Time.deltaTime * horizontalSpeed);
            yield return null;
        }
    }
    IEnumerator RightMove(){
        for(float i = 0; i<1; i += 0.1f){
            controller.Move(Vector3.right * Time.deltaTime * horizontalSpeed);
            yield return null;
        }
    }
}
