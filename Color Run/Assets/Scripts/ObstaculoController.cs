using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaculoController : MonoBehaviour
{
    public float speed;
    public float jumpHeight;
    public float gravity;
    public float horizontalSpeed;
    private float jumpVelocity;
    private CharacterController controller;
    private Transform player;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController> ();//asdasd
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frameasas
    void Update()
    {
        Vector3 direction = Vector3.back * speed;
        if(controller.isGrounded){
            if(Input.GetKeyDown(KeyCode.Space)){
                jumpVelocity = jumpHeight;
            }
        }
        else{
            jumpVelocity -= gravity;
        }
        speed += speed*(Time.deltaTime/50);
        direction.y= jumpVelocity;
        controller.Move(direction*Time.deltaTime);

         if(controller.transform.position.z < player.position.z){
             Destroy(controller.gameObject);
         }
    }
}
