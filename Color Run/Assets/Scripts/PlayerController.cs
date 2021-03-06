﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    public float speed;
    public float jumpHeight;
    public float gravity;
    public float horizontalSpeed;
    public float jumpVelocity;
    public bool isMovingR = false;
    public bool isMovingL = false;
    public bool isJumping;
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
            isJumping = false;
            if(Input.GetKeyDown(KeyCode.Space) && !isJumping){
                jumpVelocity = jumpHeight;// faz ele pular
                isJumping = true;
            }
        }

        if(Input.GetKey(KeyCode.RightArrow) && !isMovingR && transform.position.x <= 4f){
            isMovingR = true;
            StartCoroutine(RightMove());//move para a direita 
        }
        if(Input.GetKey(KeyCode.LeftArrow) && !isMovingL && transform.position.x >= -4f){
            isMovingL = true;
            StartCoroutine(LeftMove());//move para a esquerda
        } 
        if(!controller.isGrounded){
            jumpVelocity -= gravity * Time.deltaTime;
        }
        OnCollision();
        speed += speed*(Time.deltaTime/50); //incrementa velocidade com o tempo
        
        direction.y= jumpVelocity; //pular
       
        controller.Move(direction*Time.deltaTime); //mover
        if(transform.position.y < -2){
            anim.SetTrigger("die");
            speed = 0;
            jumpHeight = 0;
            horizontalSpeed = 0;
            isDead = true;
            Invoke("GameOver",1f);
        }
    }

    void OnCollision(){
        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, rayRadius, layer)){
            // Debug.Log("bateu");
            anim.SetTrigger("die");
            speed=0;
            jumpHeight=0;
            horizontalSpeed=0;
            isDead=true;
            Invoke("GameOver",1f);
            Destroy(hit.transform.gameObject);
        }
        else if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), out hit, 1f, layer)){
            // Debug.Log("bateu d");
            anim.SetTrigger("die");
            speed=0;
            jumpHeight=0;
            horizontalSpeed=0;
            isDead=true;
            Invoke("GameOver",1f);
            Destroy(hit.transform.gameObject);
        }

        else if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.left), out hit, 1f, layer)){
            // Debug.Log("bateu e");
            anim.SetTrigger("die");
            speed=0;
            jumpHeight=0;
            horizontalSpeed=0;
            isDead=true;
            Invoke("GameOver",1f);
            Destroy(hit.transform.gameObject);
        }
        else if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.up), out hit, 1f, layer)){
            // Debug.Log("bateu e");
            anim.SetTrigger("die");
            speed=0;
            jumpHeight=0;
            horizontalSpeed=0;
            isDead=true;
            Invoke("GameOver",1f);
            Destroy(hit.transform.gameObject);
        }
    }
    //método que é executado várias vezes
    IEnumerator LeftMove(){
        for(float i = 0; i<1; i += 0.1f){
            controller.Move(Vector3.left * Time.deltaTime * horizontalSpeed);
             if(Input.GetKeyDown(KeyCode.Space) && !isJumping){
                jumpVelocity = jumpHeight;// faz ele pular
                isJumping = true;
            }
            yield return null;
        }
        isMovingL = false;
    }
    IEnumerator RightMove(){
        for(float i = 0; i<1; i += 0.1f){
            controller.Move(Vector3.right * Time.deltaTime * horizontalSpeed);
            if(Input.GetKeyDown(KeyCode.Space) && !isJumping){
                jumpVelocity = jumpHeight; // faz ele pular
            }
            yield return null;
        }
        isMovingR = false;
    }
    void GameOver(){
        gc.ShowGameOver();
    }
}
