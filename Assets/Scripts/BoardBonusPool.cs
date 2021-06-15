using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardBonusPool : ObjectPool
{
    //public static BoardBonusPool Instance;

    [SerializeField] private GameObject _bonusTemplate;

    //private void Awake()
    //{
    //    Instance = this;
    //}

    private void Awake()
    {
        Initialize(_bonusTemplate);
    }

    public void SetBonus(Vector3 position, float angle)
    {
        if (TryGetObject(out GameObject poolObject))
        {
            poolObject.SetActive(true);
            poolObject.transform.position = position;
            poolObject.transform.rotation = Quaternion.Euler(new Vector3(angle, 0, 0));
            DisableObject();
        }
        else
        {
            Debug.Log("false");
        }
    }
}
