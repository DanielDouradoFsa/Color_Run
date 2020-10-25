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
    public GameObject bucket;
    private GameObject obs;
    public Transform playerPosition;
    public SpawnMap spawn;
    public Transform spot;

    void Start()
    {
        spawn = GameObject.FindGameObjectWithTag("Spawn").GetComponent<SpawnMap>();
        bucket = Resources.Load("bucket") as GameObject;
        controller = GetComponent<CharacterController> ();
        InvokeRepeating("SpawnBucket",2,1.5f);
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

    void SpawnBucket(){
        obs = bucket;
        if(!playerController.isDead){
            if(playerController.isJumping){
                Instantiate(obs,spot.position + new Vector3(0,2.75f,0),spot.rotation);
            }       
            else{
                Instantiate(obs,spot.position,spot.rotation);
            }
            if(controller.transform.position.x < -2){
                Instantiate(obs,spot.position + new Vector3(3.5f,0,0),spot.rotation);
                Instantiate(obs,spot.position + new Vector3(3.5f,2.75f,0),spot.rotation); 
            }
            else if(controller.transform.position.x > 2){
                Instantiate(obs,spot.position + new Vector3(-3.5f,0,0),spot.rotation);
                Instantiate(obs,spot.position + new Vector3(-3.5f,2.75f,0),spot.rotation);
            }
            else{
                Instantiate(obs,spot.position + new Vector3(-3.5f,0,0),spot.rotation);
                Instantiate(obs,spot.position + new Vector3(3.5f,0,0),spot.rotation);
            }
        }
    }
}
