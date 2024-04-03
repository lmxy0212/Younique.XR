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
        if (other.gameObject.tag == "Flower" || other.gameObject.tag == "SnappableFlower")
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
                if (parent.transform.childCount == 0)
                {
                    Destroy(parent);
                }
                else
                {
                    parent.AddComponent<XRInstantiateGrabbableObject>();
                    removed_obj.AddComponent<SetDynamicAttachPos>().UseDynamicAttach = true;
                }
                
                removed_obj.AddComponent<XRInstantiateGrabbableObject>();
                //XRGrabInteractable parentInter = parent.GetComponent<XRGrabInteractable>();
                //parentInter.interactionManager.UnregisterInteractable(parent.GetComponent<IXRInteractable>());
                //parentInter.interactionManager.RegisterInteractable(parent.GetComponent<IXRInteractable>());
                Debug.Log("unregisterrrrrrrrr");
            }
            if (removed_obj.GetComponent<Rigidbody>() == null)
            {
                removed_obj.AddComponent<SetDynamicAttachPos>().UseDynamicAttach = true;
                //removed_obj.AddComponent<XRGrabInteractable>();
                removed_obj.AddComponent<XRInstantiateGrabbableObject>();
                removed_obj.AddComponent<SetDynamicAttachPos>().UseDynamicAttach = true;
            }
            if (other.gameObject.tag == "SnappableFlower")
            {
                other.GetComponent<SnapObj>().isCut = true;
            }
        }
    }
}
