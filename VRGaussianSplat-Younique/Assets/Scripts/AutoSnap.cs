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
        if (other.gameObject.tag == "Flower")
        {
            other.transform.parent.gameObject.transform.position = this.transform.position;
            Debug.Log(this.name + ": snap!!!" + other.gameObject.name);
            other.transform.parent.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            other.transform.parent.SetParent(this.transform);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Flower")
        {
            Debug.Log("moveddddddd" + other.gameObject.name);
            other.transform.parent.gameObject.GetComponent<Rigidbody>().isKinematic = false;
            other.transform.parent.SetParent(null);
        }
    }

}
