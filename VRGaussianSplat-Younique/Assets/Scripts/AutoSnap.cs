using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoSnap : MonoBehaviour
{
    public bool isSnapped;
    void Start()
    {
        
    }


    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Flower" && !isSnapped)
        {
            other.transform.parent.gameObject.transform.position = this.transform.position;
            Debug.Log(this.name + ": snap!!!" + other.gameObject.name);
            other.transform.parent.gameObject.GetComponent<Rigidbody>().useGravity = false;
            other.transform.parent.SetParent(this.transform);
            isSnapped = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Flower" && isSnapped)
        {
            isSnapped = false;
            other.transform.parent.gameObject.GetComponent<Rigidbody>().isKinematic = false;
            other.transform.parent.SetParent(null);
            Debug.Log("moveddddddd" + other.gameObject.name);
        }
    }

}
