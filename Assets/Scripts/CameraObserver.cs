using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraObserver : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _smoothTime = 0.25f;
    [SerializeField] private Vector3 _offset = new(0f, 0f, -30f);

    private Vector3 _velocity = Vector3.zero;

    private void Update()
    {
        Vector3 targetPosition = _target.position + _offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _velocity, _smoothTime);
    }
}
