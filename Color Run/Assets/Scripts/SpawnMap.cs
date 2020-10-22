using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnMap : MonoBehaviour
{
    public List<GameObject> platforms = new List<GameObject>();
    public List<Transform> currentPlatform = new List<Transform>();
    public int offset;
    public Transform player;
    private PlayerController pc;
    private Transform currentPoint;
    public int platformIndex =0;
    private int count = 1;
    private GameController gc;
    public Text timeText;
    public int timeCount =3;
    public int color;
    private bool isSorted;
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        gc = FindObjectOfType<GameController>();
        pc = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

        for(int i=0; i<platforms.Count; i++){
            Transform p = Instantiate(platforms[i], new Vector3(0,0,86*i), transform.rotation).transform; //spawna os 3 primeiros
            currentPlatform.Add(p);
            offset += 86;
        }

        currentPoint = currentPlatform[platformIndex].GetComponent<Platform>().point;
        if(!pc.isDead){
            InvokeRepeating("SortColor",2,10);
            InvokeRepeating("Temporizador",0,1);
        }
    }

    void Update()
    { 
        float distance = player.position.z - 86*(count);
        if(distance >= 0){
            Recycle(currentPlatform[platformIndex].gameObject);
            platformIndex ++;
            count++;
            if(platformIndex > currentPlatform.Count -1){
                platformIndex = 0;
            }
            currentPoint = currentPlatform[platformIndex].GetComponent<Platform>().point; 
        }
    }

    public void Recycle(GameObject platform){
        platform.transform.position = new Vector3(0,0,offset); //reposiciona as plataformas
        offset += 86;
    }

    public void SortColor(){
        color = Random.Range(0,3);
        isSorted = true;
        if(color == 0){
            gc.amarelo();
            // BuildObstaculo();
        }
        if(color == 1){
            gc.azul();
            // BuildObstaculo();
        }
        if(color == 2){
            gc.vermelho();
            // BuildObstaculo();
        }
        // BuildObstaculo();
    }

    void Temporizador(){
        if(isSorted){
            timeText.gameObject.SetActive(true);
            timeText.text = timeCount.ToString() + "s";
            timeCount --;
        }
        if(timeCount < 0){
            timeCount = 3;
            timeText.gameObject.SetActive(false);
            isSorted = false;
        }
    }
}
