using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField]
    T objectToInstantiate;

    public T ObjectToInstantiate
    {
        set
        {
            objectToInstantiate = value;
        }
    }

    [SerializeField]
    int initialSize;

    [SerializeField]
    bool canIncrease;

    [SerializeField]
    bool setsParentToThisObject;

    List<T> pool = new List<T>();

    protected void Start()
    {
        InitializePool();
    }


    public void DisableAllObjects()
    {
        foreach (T obj in pool)
        {
            obj.gameObject.SetActive(false);
        }
    }

    protected void InitializePool()
    {
        for (int i = 0; i < initialSize; i++)
        {
            InstantiateObject();
        }
    }

    protected T InstantiateObject()
    {
        T obj = setsParentToThisObject ? Instantiate(objectToInstantiate, transform) : Instantiate(objectToInstantiate);
        obj.gameObject.SetActive(false);

        pool.Add(obj);

        return obj;
    }

    /// <summary>
    /// Returns an inactive object, if objects are available.
    /// </summary>
    /// <returns></returns>
    public T GetObject()
    {
        foreach (T obj in pool)
        {
            if (!obj.gameObject.activeInHierarchy)
            {
                return obj;
            }
        }

        if (!canIncrease)
        {
            return null;
        }

        return InstantiateObject();
    }
}
