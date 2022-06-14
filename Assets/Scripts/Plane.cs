using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{
    [SerializeField] private float _arc;
    public Transform StartPos, TargetPos;


    private float _time = 0;

    void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            _time += Time.deltaTime;
            float duration = 1f;
            float t01 = _time / duration;
            Vector3 pos = Vector3.Lerp(StartPos.position, TargetPos.position, t01);
            
            Vector3 arc = Vector3.right * _arc * Mathf.Sin(_time * Mathf.PI);

            transform.position = pos +arc;
        }
    }
}
