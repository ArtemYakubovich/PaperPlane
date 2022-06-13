using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trajectory : MonoBehaviour
{
    public Transform startPos, midPos, endPos;
    public LineRenderer lineVisual;
    public int lineSegment;

    private void Start()
    {
        lineVisual.positionCount = lineSegment;
        startPos.position = gameObject.transform.position;
        endPos.position = gameObject.transform.position + new Vector3(0,0,20f);
        
        lineVisual.SetPosition(0, startPos.position);
        lineVisual.SetPosition(1, endPos.position);
    }
}