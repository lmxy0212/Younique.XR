using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandMenuInteracter : MonoBehaviour
{
    public MenuController menuControllerScript;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("HAND Collide! " + other.transform.gameObject.name);
        if (other.transform.gameObject.tag == "Menu") 
        {
            menuControllerScript.toggleMenuBtns = true;
        }
    }
}
