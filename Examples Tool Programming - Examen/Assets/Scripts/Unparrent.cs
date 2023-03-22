using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class UnparentCamera : MonoBehaviour
{
    void Awake()
    {
        transform.parent = null;
    }



// Update is called once per frame
    void Update()
    {
        
    }
}
