using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class SnappablePlate : MonoBehaviour
{
    public bool isSnaped;
    public GameObject snapPos;

    void Start()
    {
    }

    void Update()
    {
        if (isSnaped)
        {
            transform.position = snapPos.transform.position;
            transform.rotation = snapPos.transform.rotation;
            if (GetComponent<XRGrabInteractable>())
            {
                Destroy(GetComponent<XRGrabInteractable>());
            }
        }
    }
}
