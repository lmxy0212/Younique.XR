using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReenablePhysics : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Flower")
        {
            other.transform.parent.gameObject.transform.position = this.transform.position;
            Debug.Log(this.name + ": physics!!!" + other.gameObject.name);
            other.transform.parent.gameObject.GetComponent<Rigidbody>().isKinematic = false;
            other.transform.parent.SetParent(null);
        }

    }

}
