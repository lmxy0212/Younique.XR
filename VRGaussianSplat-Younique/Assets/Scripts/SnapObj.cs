using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapObj : MonoBehaviour
{
    public bool isSnaped;
    void Start()
    {
        
    }

    void Update()
    {
        if (!isSnaped)
        {
            transform.SetParent(null);
            GetComponent<Rigidbody>().isKinematic = false;
        }
    }
}