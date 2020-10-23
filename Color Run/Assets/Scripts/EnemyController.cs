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
        speed = -playerController.speed;
        horizontalSpeed = playerController.horizontalSpeed/1.5f;
        Vector3 direction = Vector3.back * speed;
        
        if(controller.transform.position.x < playerPosition.position.x && controller.transform.position.x - playerPosition.position.x <= 0.5 && playerPosition.position.x > -4.92){
            controller.Move(Vector3.right * Time.deltaTime * horizontalSpeed); 
        }
        else if(controller.transform.position.x > playerPosition.position.x && (controller.transform.position.x - playerPosition.position.x >= 0.5) && playerPosition.position.x < 4.92){
            controller.Move(Vector3.left * Time.deltaTime * horizontalSpeed);
        }


        speed += speed*(Time.deltaTime/50); //incrementa velocidade com o tempo
       
        controller.Move(direction*Time.deltaTime); //mover

        if(playerController.isDead){
            speed = 0;
            horizontalSpeed = 0;
        }
    }

    // IEnumerator LeftMove(){
    //     for(float i = 0; i<1; i += 0.1f){
    //         controller.Move(Vector3.left * Time.deltaTime * horizontalSpeed);
    //         yield return null;
    //     }
    // }
    // IEnumerator RightMove(){
    //     for(float i = 0; i<1; i += 0.1f){
    //         controller.Move(Vector3.right * Time.deltaTime * horizontalSpeed);
    //         yield return null;
    //     }
    // }
}
