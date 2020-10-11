using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMap : MonoBehaviour
{
    public List<GameObject> platforms = new List<GameObject>();
    public List<Transform> currentPlatform = new List<Transform>();
    public int offset;
    public Transform player;
    private Transform currentPoint;
    public int platformIndex =0;
    private int count = 1;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        for(int i=0; i<platforms.Count; i++){
            Transform p = Instantiate(platforms[i], new Vector3(0,0,86*i), transform.rotation).transform; //spawna os 3 primeiros
            currentPlatform.Add(p);
            offset += 86;
        }

        currentPoint = currentPlatform[platformIndex].GetComponent<Platform>().point;
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
            // Debug.Log(currentPoint.position.z);
        }
    }

    public void Recycle(GameObject platform){
        platform.transform.position = new Vector3(0,0,offset); //reposiciona as plataformas
        offset += 86;
    }
}
