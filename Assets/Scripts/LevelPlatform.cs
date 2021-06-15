using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelPlatform : MonoBehaviour
{
    [SerializeField] private Transform _scateboard;
    [SerializeField] private BoardBonusPool _boardBonusPool;
    [SerializeField] private List<Platform> _platforms = new List<Platform>();

    [SerializeField] private float _distanceCreate;
    [SerializeField] private int _startPlatformCreate;

    [SerializeField] private float _offsetZ;
    [SerializeField] private Vector2 _rangeOffsetX;

    [Range(1,100)]
    [SerializeField] private int _Random;

    private bool HavePlatform => _index < _platforms.Count;

    private int _index;

    private void Start()
    {
        for (int i = 0; i < _startPlatformCreate; i++)
        {
            GenerateBonus(_platforms[i]);
        }
        _index = _startPlatformCreate ;
    }

    private void Update()
    {
        if (HavePlatform)
        {
            if (_platforms[_index].transform.position.z < _scateboard.position.z + _distanceCreate)
            {
                GenerateBonus(_platforms[_index]);
                _index++;
            }
        }
    }

    private void GenerateBonus(Platform platform)
    {
        Vector3 _curent = platform.PointFrom;

        Vector3 targetDir = platform.PointTo - platform.PointFrom;
        float angle = Vector3.Angle(targetDir, Vector3.forward);

        float offsetY = CalculateStep(platform);
        Vector3 offsetX = Vector3.zero;

        while (_curent.z < platform.PointTo.z)
        {
            if (Random.Range(0, 100) > _Random)
            {
                _curent.z += _offsetZ;
                _curent.y -= offsetY;
                continue;
            }

            offsetX = Vector3.zero;
            offsetX.x = Random.Range(_rangeOffsetX.x, _rangeOffsetX.y);
            _boardBonusPool.SetBonus(_curent + offsetX, angle);
            _curent.z += _offsetZ;
            _curent.y -= offsetY;
        }
    }

    private float CalculateStep(Platform platform)
    {
        float valueY = platform.PointFrom.y - platform.PointTo.y;
        float valueZ = Mathf.Abs(platform.PointTo.z - platform.PointFrom.z);
        float count = valueZ / _offsetZ;
        return valueY / count;
    }
}
