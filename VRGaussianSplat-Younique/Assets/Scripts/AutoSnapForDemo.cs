using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnLogickFactory;

public class AutoSnapForDemo : MonoBehaviour
{
    public CustomFbxExporterForDemo saveController;
    private bool snapped;

    void Start()
    {
        
    }
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        GameObject parentObj = other.gameObject;
        if (other.gameObject.tag == "Plate" && !parentObj.GetComponent<SnappablePlate>().isSnaped && !snapped)
        {
            snapped = true;
            parentObj.transform.position = this.transform.position;
            Debug.Log(this.name + ": Enter" + other.gameObject.name);
            parentObj.GetComponent<Rigidbody>().isKinematic = true;
            parentObj.GetComponent<SnappablePlate>().isSnaped = true;
            parentObj.GetComponent<MeshCollider>().isTrigger = true;
            Destroy(parentObj.GetComponent<PlayAudio>());
            Destroy(parentObj.GetComponent<XRGrabInteractable>());
            saveController.objectToExport = parentObj;
        }
    }
   

}
