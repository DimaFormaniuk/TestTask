using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardBonus : MonoBehaviour
{
    [SerializeField] private int _boardValue = 5;
    public int Value { get; private set; }

    private void Awake()
    {
        Value = _boardValue;
    }


}
