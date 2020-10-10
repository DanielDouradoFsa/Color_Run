using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public Transform point;
    void Start()
    {
        point = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
