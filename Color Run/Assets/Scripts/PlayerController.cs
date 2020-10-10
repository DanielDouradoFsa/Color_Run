using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
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
        speed += speed*(Time.deltaTime/50); //incrementa velocidade com o tempo
        direction.y= jumpVelocity; //pular
        controller.Move(direction*Time.deltaTime); //mover
    }
}
