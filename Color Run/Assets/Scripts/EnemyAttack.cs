using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public CharacterController body;
    public float speed;
    private PlayerController pc;
    void Start()
    {
        body = GetComponent<CharacterController>();
        pc = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    void Update(){
        // transform.position += new Vector3(0, 1, 1*Time.deltaTime);
        Vector3 direction = Vector3.back * speed;
        body.Move(direction*Time.deltaTime); //mover
        speed += speed*(Time.deltaTime/100);
        WithoutCollision();
    }

    void WithoutCollision(){
        if(pc.transform.position.z - this.transform.position.z > 5){
            Destroy(this.gameObject);
        }
    }   
}
