using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TinyGiantStudio.Text;
public class NameTagController : MonoBehaviour
{
    public GameObject tagObj;
    public Modular3DText Text;
    public GameObject TextObj;

    void Start()
    {
        //tagObj.SetActive(false);
        Text.UpdateText("");
        
    }
    void Update()
    {
        Debug.Log(TextObj.GetComponent<MeshFilter>().sharedMesh.isReadable);
    }
}
