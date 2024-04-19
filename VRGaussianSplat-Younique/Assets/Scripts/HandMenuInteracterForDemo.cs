using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnLogickFactory;

public class HandMenuInteracterForDemo : MonoBehaviour
{
    public MenuControllerMotionGraph menuControllerScript;
    public CustomFbxExporterForDemo fbxExporter;
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
        if (other.transform.gameObject.tag == "Camera-Btn")
        {
            Debug.Log("CAMERA BTN");
            fbxExporter.enableExport = true;
        }
    }
}
