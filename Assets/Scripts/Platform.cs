using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private Transform _pointFrom;
    [SerializeField] private Transform _pointTo;

    public Vector3 PointFrom => _pointFrom.position;
    public Vector3 PointTo => _pointTo.position;
}
