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
    private Transform currentPoint;
    public int platformIndex =0;
    private int count = 1;
    private GameController gc;
    private int color = 1;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        gc = FindObjectOfType<GameController>();

        for(int i=0; i<platforms.Count; i++){
            Transform p = Instantiate(platforms[i], new Vector3(0,0,86*i), transform.rotation).transform; //spawna os 3 primeiros
            currentPlatform.Add(p);
            offset += 86;
        }

        currentPoint = currentPlatform[platformIndex].GetComponent<Platform>().point;
        InvokeRepeating("sortColor",3,10);
    }

    void Update()
    { 
        float distance = player.position.z - 86*(count);
        // Invoke("sortColor",3f);
        if(distance >= 0){
            Recycle(currentPlatform[platformIndex].gameObject);
            platformIndex ++;
            count++;
            if(platformIndex > currentPlatform.Count -1){
                platformIndex = 0;
            }
            currentPoint = currentPlatform[platformIndex].GetComponent<Platform>().point; 
        }
        // Invoke("sortColor",3f);
    }

    public void Recycle(GameObject platform){
        platform.transform.position = new Vector3(0,0,offset); //reposiciona as plataformas
        offset += 86;
    }

    public void sortColor(){
        if(color == 1){
            Debug.Log("Amarelo");
            gc.amarelo();

        }
        if(color == 2){
            Debug.Log("Azul");
            gc.azul();
        }
        if(color == 3){
            Debug.Log("Vermelho");
            gc.vermelho();
        }
        color++;
        if(color >= 4)
            color = 0;
    }
}
