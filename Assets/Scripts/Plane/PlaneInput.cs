using System;
using UnityEngine;

public class PlaneInput : MonoBehaviour
{
    public Transform[] BezierPos;
    [SerializeField] private Plane _plane;
    [SerializeField] private float _widthDevisor = 128f;
    [SerializeField] private float _widthMaxLocalPos;
    
    private float _withPixelCam;
    private Vector2 _firstContact, _nowContact, _lastContact;

    private void Start()
    {
        _withPixelCam = Camera.main.pixelWidth;
        _widthDevisor = _withPixelCam / _widthDevisor;
    }

    private void Update()
    {
        TouchControll();
    }

    private void TouchControll()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                _firstContact = touch.position;
            }

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    _firstContact = touch.position;
                    break;
                case TouchPhase.Moved:
                    _lastContact = touch.position;
                    float distance = _firstContact.x - _lastContact.x;
                    ChangeTragectoryPos(Mathf.Clamp(distance / _widthDevisor, -_widthMaxLocalPos, _widthMaxLocalPos));
                    break;
                case TouchPhase.Ended:
                    _plane.Move = true;
                    break;
                default:
                    break;
            }
        }
    }

    private void ChangeTragectoryPos(float distance)
    {
        float saveDistance = distance;
        if (distance <= saveDistance)
        {
            BezierPos[1].position = new Vector3(distance, BezierPos[1].transform.position.y, BezierPos[1].transform.position.z);
            saveDistance = distance;
        }
    }
}
