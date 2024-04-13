using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnLogickFactory;

public class SnappablePlate : MonoBehaviour
{
    public bool isSnaped;
    public GameObject snapPos;
    public CustomFbxExporter saveController;
    void Start()
    {

    }

    void Update()
    {
        if (!isSnaped)
        {
            transform.SetParent(null);
            if (GetComponent<Rigidbody>() != null)
            {
                GetComponent<Rigidbody>().isKinematic = false;
            }

        }
        if (isSnaped)
        {
            transform.SetParent(snapPos.transform);
            saveController.objectToExport = gameObject;
        }
    }
}
