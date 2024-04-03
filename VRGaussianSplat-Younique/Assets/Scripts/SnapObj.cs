using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapObj : MonoBehaviour
{
    public bool isCut;
    public bool isSnaped;
    void Start()
    {
        
    }

    void Update()
    {
        if (isCut && !isSnaped)
        {
            transform.SetParent(null);
            if (GetComponent<Rigidbody>() != null)
            {
                GetComponent<Rigidbody>().isKinematic = false;
            }
            
        }
    }
}
