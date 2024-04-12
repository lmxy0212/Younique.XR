using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapContainer : MonoBehaviour
{
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        GameObject parentObj = other.gameObject; // obj to be snapped
        if (other.gameObject.tag == "Plate" && !parentObj.GetComponent<SnappablePlate>().isSnaped)
        {
            parentObj.transform.position = this.transform.position;
            Debug.Log(this.name + ": Enter" + other.gameObject.name);
            parentObj.GetComponent<Rigidbody>().isKinematic = true;
            parentObj.GetComponent<SnappablePlate>().isSnaped = true;
            other.transform.parent.SetParent(this.transform);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        GameObject parentObj = other.gameObject;
        if (other.gameObject.tag == "Plate" && parentObj.GetComponent<SnappablePlate>().isSnaped)
        {
            parentObj.GetComponent<SnappablePlate>().isSnaped = false;
            Debug.Log(this.name + ": Exit!!!" + other.gameObject.name);
        }
    }
}
