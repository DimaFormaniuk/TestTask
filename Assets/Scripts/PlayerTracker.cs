using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTracker : MonoBehaviour
{
    [SerializeField] private PlayerMove _player;
    [SerializeField] private Vector3 _offsetPosition;

    private void Start()
    {
        transform.localPosition = _player.transform.position + _offsetPosition;
    }

    private void Update()
    {
        transform.position = _player.transform.position;
        transform.localPosition += _offsetPosition;
    }
}
