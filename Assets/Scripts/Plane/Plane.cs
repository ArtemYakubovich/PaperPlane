using System;
using UnityEditor.UIElements;
using UnityEngine;

public class Plane : MonoBehaviour
{
    public bool Move;
    public Transform[] BezierPos;
    
    [SerializeField] private PlaneInput _planeInput;
    [SerializeField] private GameObject _trajectory;
    [SerializeField] private float _speed;

    private Rigidbody _body;
    private float _timePlanePos = 0f;

    private void Awake()
    {
        _body = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Move)
        {
            _trajectory.SetActive(false);
            _timePlanePos += Time.deltaTime * _speed;
            
            transform.position =
                Bezier.GetPoint(BezierPos[0].position, BezierPos[1].position, BezierPos[2].position, _timePlanePos);
            transform.rotation = Quaternion.LookRotation(Bezier.GetFirstDerivative(BezierPos[0].position,
                BezierPos[1].position, BezierPos[2].position, _timePlanePos));
        }
    }
}
