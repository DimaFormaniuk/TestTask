using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private Transform _container;
    [SerializeField] private int _capacity;
    [SerializeField] private float _offsetZ;
    [SerializeField] private Transform _disablePoint;

    private List<GameObject> _pool = new List<GameObject>();

    protected void Initialize(GameObject prefab)
    {
        for (int i = 0; i < _capacity; i++)
        {
            GameObject spawn = Instantiate(prefab, _container);
            spawn.gameObject.SetActive(false);

            _pool.Add(spawn);
        }
    }

    protected bool TryGetObject(out GameObject result)
    {
        result = _pool.FirstOrDefault(p => p.activeSelf == false);
        return result != null;
    }

    protected void DisableObject()
    {
        foreach (var item in _pool)
        {
            if (item.activeSelf == true)
            {
                if (item.transform.position.z < _disablePoint.position.z+_offsetZ)
                {
                    item.SetActive(false);
                }
            }
        }
    }

    protected void ResetPool()
    {
        foreach (var item in _pool)
            item.SetActive(false);
    }

    protected void Clear()
    {
        for (int i = 0; i < _pool.Count; i++)
        {
            Destroy(_pool[i]);
        }
    }
}
