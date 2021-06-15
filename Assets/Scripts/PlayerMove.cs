using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMove : MonoBehaviour
{
    [SerializeField] private Transform _scateboard;
    [SerializeField] private float _speed;
    [SerializeField] private float _offsetY;
    private Vector3 _diraction = Vector3.forward;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        //_scateboard.position = new Vector3(transform.position.x, transform.position.y + _offsetY, transform.position.z);
    }

    private void FixedUpdate()
    {
        _rigidbody.AddForce(_diraction * _speed);
        _scateboard.position = new Vector3(transform.position.x, transform.position.y + _offsetY, transform.position.z);
    }
}

//if (_rigidbody.velocity.magnitude > _maxSpeed)
//    _rigidbody.velocity *= _maxSpeed / _rigidbody.velocity.magnitude;

//if (Input.touchCount > 0)
//{
//    Touch touch = Input.GetTouch(0);
//    _rigidbody.velocity = new Vector3(_rigidbody.velocity.x, touch.deltaPosition.y * offsetSpeed, _rigidbody.velocity.z);
//}