using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuilBoard : MonoBehaviour
{
    [SerializeField] private AcumulateBoard _acumulateBoard;
    [SerializeField] private BoardPlatformPool _boardPlatformPool;

    [SerializeField] private int _countStartPlatform;
    [SerializeField] private float _offsetBetweenBoard;
    [SerializeField] private Vector2 _offsetFromToY;

    [SerializeField] private int _countForward;

    [SerializeField] private Slider _slider;
    [SerializeField] private CanvasGroup _canvasGroup;

    private Vector3 _tapPosition;
    private Vector3 _diractions;
    private Vector3 _lastPosition;

    private void Start()
    {
        _canvasGroup.alpha = 0;
        _slider.value = 0;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _tapPosition = Input.mousePosition;
            Down();

            _canvasGroup.alpha = 1;
            _slider.value = 0;
            _slider.transform.position = _tapPosition;
        }

        if (Input.GetMouseButton(0))
        {
            _diractions = Input.mousePosition - _tapPosition;
            Build();
        }

        if (Input.GetMouseButtonUp(0))
        {
            _canvasGroup.alpha = 0;
            _slider.value = 0;
        }
    }

    private void Down()
    {
        float offsetY = CalculateStep();
        Vector3 temp = new Vector3(transform.position.x, transform.position.y + _offsetFromToY.x, transform.position.z);

        float angle = Vector3.Angle(new Vector3(0, offsetY, _offsetBetweenBoard), Vector3.forward);

        for (int i = 0; i < _countStartPlatform; i++)
        {
            PositionBoard(temp, -angle);
            temp += new Vector3(0, offsetY, _offsetBetweenBoard);
        }
    }

    private float CalculateStep()
    {
        float value = Mathf.Abs(_offsetFromToY.x) + Mathf.Abs(_offsetFromToY.y);
        return value / _countStartPlatform;
    }

    private void Build()
    {
        float distance = _offsetBetweenBoard * (float)_countForward;

        if (transform.position.z + distance >= _lastPosition.z)
        {
            float offsetY = _slider.value;
            Vector3 nextPosition = new Vector3(_lastPosition.x, _lastPosition.y + offsetY, _lastPosition.z + _offsetBetweenBoard);
            Vector3 targetDir = nextPosition - _lastPosition;
            float angle = Vector3.Angle(targetDir, Vector3.forward);
            if (offsetY > 0) angle = -angle;
            PositionBoard(nextPosition, angle);
        }
    }

    private void PositionBoard(Vector3 position, float angle)
    {
        if (_acumulateBoard.HaveBoard)
        {
            _boardPlatformPool.SetPlatform(position, angle);
            _lastPosition = position;
            _acumulateBoard.SubBoard();
        }
    }
}
