using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class TwoPoiintLine : MonoBehaviour
{
    public Transform fromPoint;
    public Transform toPoint;
    private LineRenderer line;
    void Start()
    {
        line = GetComponent<LineRenderer>();
        
    }
    void Update()
    {
        line.positionCount = 2;
        line.SetPosition(0, fromPoint.position);
        line.SetPosition(1, toPoint.position);
    }
}
