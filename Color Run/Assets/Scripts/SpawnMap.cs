using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMap : MonoBehaviour
{
    public List<GameObject> platforms = new List<GameObject>();
    public int offset;
    void Start()
    {
        for(int i=0; i<platforms.Count; i++){
            Instantiate(platforms[i], new Vector3(0,0,86*i), transform.rotation);
            offset += 86;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Recycle(GameObject platform){
        platform.transform.position = new Vector3(0,0,offset);
        offset += 86;
    }
}
