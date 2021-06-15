using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardPlatformPool : ObjectPool
{
    [SerializeField] private GameObject _boardTemplate;

    private void Start()
    {
        Initialize(_boardTemplate);
    }

    public void SetPlatform(Vector3 position, float angle)
    {
        if (TryGetObject(out GameObject platform))
        {
            platform.SetActive(true);
            platform.transform.position = position;
            platform.transform.rotation = Quaternion.Euler(new Vector3(angle, 0, 0));
            DisableObject();
        }
    }
}
