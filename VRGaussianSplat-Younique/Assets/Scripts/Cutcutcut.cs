using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class Cutcutcut : MonoBehaviour
{
    public GameObject removed_obj;
    public GameObject parent;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Flower")
        {
            removed_obj = other.gameObject;
            if (removed_obj.transform.parent != null)
            {
                parent = removed_obj.transform.parent.gameObject;
            }
            removed_obj.transform.SetParent(null);
            if (parent != null)
            {
                Destroy(parent.GetComponent<XRGrabInteractable>());
                if (parent.GetComponent<XRInstantiateGrabbableObject>())
                {
                    Destroy(parent.GetComponent<XRInstantiateGrabbableObject>());
                }
                
                parent.AddComponent<XRGrabInteractable>();
                removed_obj.AddComponent<XRInstantiateGrabbableObject>();
                //XRGrabInteractable parentInter = parent.GetComponent<XRGrabInteractable>();
                //parentInter.interactionManager.UnregisterInteractable(parent.GetComponent<IXRInteractable>());
                //parentInter.interactionManager.RegisterInteractable(parent.GetComponent<IXRInteractable>());
                Debug.Log("unregisterrrrrrrrr");
            }
            if (removed_obj.GetComponent<Rigidbody>() == null)
            {
                removed_obj.AddComponent<XRGrabInteractable>();
                removed_obj.AddComponent<XRInstantiateGrabbableObject>();
            }
        }
    }
}
