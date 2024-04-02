using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoSnap : MonoBehaviour
{
    void Start()
    {
        
    }


    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject parentObj = other.transform.parent.gameObject;
        if (other.gameObject.tag == "Flower" && !parentObj.GetComponent<SnapObj>().isSnaped)
        {
            parentObj.transform.position = this.transform.position;
            Debug.Log(this.name + ": Enter" + other.gameObject.name);
            parentObj.GetComponent<Rigidbody>().isKinematic = true;
            parentObj.GetComponent<SnapObj>().isSnaped = true;
            other.transform.parent.SetParent(this.transform);
        }

    }
    private void OnTriggerExit(Collider other)
    {
        GameObject parentObj = other.transform.parent.gameObject;
        if (other.gameObject.tag == "Flower" && parentObj.GetComponent<SnapObj>().isSnaped)
        {            
            parentObj.GetComponent<SnapObj>().isSnaped = false;
            Debug.Log(this.name + ": Exit!!!" + other.gameObject.name);
        }
    }

}
