using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    private CharacterController controller;

    public float speed;
    public float jumpHeight;
    public float gravity;
    private float jumpVelocity;

    void Start()
    {
        controller = GetComponent<CharacterController> ();
    }

    // Update is called once per frame
    void Update()
    {
        //foward é o eixo Z para frente
        Vector3 direction = Vector3.forward * speed;
        if(controller.isGrounded){
            if(Input.GetKeyDown(KeyCode.Space)){
                jumpVelocity = jumpHeight; // faz ele pular
            }
        }
        else{
            jumpVelocity -= gravity; //faz ele cair
        }

        direction.y= jumpVelocity; //pular
        controller.Move(direction*Time.deltaTime); //mover
    }
}
