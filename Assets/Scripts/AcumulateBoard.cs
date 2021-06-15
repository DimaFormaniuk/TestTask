using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AcumulateBoard : MonoBehaviour
{
    public event UnityAction<int> UpdateCount;
    [SerializeField] private int _startCountBoard;
    public bool HaveBoard => _countBoard != 0;
    private int _countBoard;

    private void Start()
    {
        _countBoard = _startCountBoard;
    }

    public void SubBoard()
    {
        if (HaveBoard == true)
        {
            _countBoard--;
            UpdateCount?.Invoke(_countBoard);
        }
    }

    private void AddBoard(int value)
    {
        if (value > 0)
        {
            _countBoard += value;
            UpdateCount?.Invoke(_countBoard);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out BoardBonus boardBonus))
        {
            boardBonus.gameObject.SetActive(false);
            AddBoard(boardBonus.Value);
        }
    }
}
