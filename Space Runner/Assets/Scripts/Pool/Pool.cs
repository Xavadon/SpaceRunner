using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    [SerializeField] private PoolObject[] _prefab;
    [SerializeField] private Transform _transform;

    [Space(height: 10)]
    [SerializeField] private int _minCapasity;
    [SerializeField] private int _maxCapasity;

    [Space(height:10)]
    [SerializeField] private  bool _autoExpand;

    private List<PoolObject> _pool;

    private void Start()
    {
        CreatePool();
    }

    private void OnValidate()
    {
        if (_autoExpand)
        {
            _maxCapasity = 3000;
        }
    }

    private void CreatePool()
    {
        _pool = new List<PoolObject>(_minCapasity);

        for (int i = 0; i < _minCapasity; i++)
        {
            CreateElement();
        }
    }

    private PoolObject CreateElement(bool isActiveByDefault = false)
    {
        var createObject = Instantiate(_prefab[Random.Range(0,_prefab.Length)], _transform);
        createObject.transform.parent = gameObject.transform;
        createObject.gameObject.SetActive(false);

        _pool.Add(createObject);

        return createObject;
    }

    public bool TryGetElement(out PoolObject element)
    {
        foreach (var item in _pool)
        {
            if (!item.gameObject.activeInHierarchy)
            {
                element = item;
                item.gameObject.SetActive(true);
                return true;
            }
        }

        element = null;
        return false;
    }

    public PoolObject GetFreeElement(Vector3 position)
    {
        var element = GetFreeElement();
        element.transform.position = position;
        element.gameObject.SetActive(true);
        return element;
    }

    public PoolObject GetFreeElement()
    {
        if (TryGetElement(out var element))
        {
            return element;
        }
        if (_autoExpand)
        {
            return CreateElement(true);
        }
        if (_pool.Count < _maxCapasity)
        {
            return CreateElement(true);
        }

        Debug.Log("Pool is over!");
        return null;
    }
}
