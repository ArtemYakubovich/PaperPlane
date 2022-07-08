using System;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform[] _cameraPos;
    [SerializeField] private float speed;
    [SerializeField] private float position;
    [SerializeField] private bool Move = false;
    [SerializeField] private int _countPos = 0;
    [SerializeField] private GameUI _gameUI;

    private void Start()
    {
        _gameUI = FindObjectOfType<GameUI>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Move = true;
            _countPos++;
        }
        
        if (Move)
        {
            position += speed * Time.deltaTime;
            position = Mathf.Clamp01(position);
            transform.position = Vector3.Lerp(_cameraPos[_countPos - 1].position, _cameraPos[_countPos].position, position);
            if (position == 1)
            {
                _gameUI.ShowPartLevelUI(_countPos);
                Move = false;
                position = 0;
            }
        }
    }
}
