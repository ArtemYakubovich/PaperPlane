using UnityEngine;

public class Trajectory : MonoBehaviour
{
    [SerializeField] private Transform _p0, _p1, _p2;
    [SerializeField] private GameObject _pref;
    [SerializeField] private int _countSegments;
    private Transform[] _segments;

    private void Start()
    {
        _segments = new Transform[_countSegments];
        for (int i = 0; i < _segments.Length; i++)
        {
            GameObject newSegment = Instantiate(_pref);
            newSegment.transform.parent = transform;
            newSegment.name = $"Segment_{i}";
            _segments[i] = newSegment.transform;
        }
    }

    private void Update()
    {
        for (int i = 0; i < _segments.Length; i++)
        {
            _segments[i].position = Bezier.GetPoint(_p0.position, _p1.position, _p2.position, (float)i / (_countSegments - 1));
        }
    }
}
