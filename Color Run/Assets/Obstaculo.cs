using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstaculo : MonoBehaviour
{
    public float speed;
    public float jumpHeight;
    public float gravity;
    public float horizontalSpeed;
    private float jumpVelocity;
    private CharacterController controller;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController> ();//asdasd
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
    }
}
