using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagBoards : MonoBehaviour
{
    [SerializeField] private GameObject _boardTemplate;
    [SerializeField] private AcumulateBoard _acumulateBoard;
    [SerializeField] private int _startSpawn;

    [SerializeField] private float _offsetX;
    [SerializeField] private float _offsetY;

    private List<GameObject> _boards = new List<GameObject>();
    private float _sizeX;
    private float _sizeY;

    private Vector3 _lastPoint;

    private void Awake()
    {
        _sizeX = _boardTemplate.transform.localScale.x;
        _sizeY = _boardTemplate.transform.localScale.y;

        _lastPoint = transform.localPosition;
        _lastPoint.y = 0;
    }

    private void Start()
    {
        for (int i = 0; i < _startSpawn; i++)
        {
            Creat();
        }
    }

    private void OnEnable()
    {
        _acumulateBoard.UpdateCount += OnUpdateCount;
    }

    private void OnDisable()
    {
        _acumulateBoard.UpdateCount -= OnUpdateCount;
    }

    private void OnUpdateCount(int value)
    {
        if (_boards.Count < value)
        {
            while (_boards.Count < value)
            {
                Creat();
            }
        }

        for (int i = 0; i < _boards.Count; i++)
        {
            _boards[i].SetActive(i < value);
        }
    }

    private void Creat()
    {
        Vector3 position = Vector3.zero;

        position = _lastPoint;
        position.x += _sizeX + _offsetX;
        position.z = 0;
        Create(position);

        position = _lastPoint;
        position.x += -_sizeX - _offsetX;
        position.z = 0;
        Create(position);

        _lastPoint.y += _sizeY + _offsetY;
    }

    private void Create(Vector3 position)
    {
        var obj = Instantiate(_boardTemplate);
        obj.transform.parent = transform;
        obj.transform.localPosition = position;
        obj.SetActive(false);      
        
        _boards.Add(obj);
    }
}
