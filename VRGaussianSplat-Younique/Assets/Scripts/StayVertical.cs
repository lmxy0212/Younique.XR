using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayVertical : MonoBehaviour
{
    public Transform target;

    void Start()
    {
        
    }

    void Update()
    {
        transform.LookAt(target, Vector3.up);
    }
}
