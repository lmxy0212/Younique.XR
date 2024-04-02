using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutcutcut : MonoBehaviour
{
    public GameObject removed_obj;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Flower")
        {
            removed_obj = other.gameObject;
            removed_obj.transform.SetParent(null);
            if (removed_obj.GetComponent<Rigidbody>() == null)
            {
                removed_obj.AddComponent<Rigidbody>();
                removed_obj.AddComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();
            }
        }
    }
}
