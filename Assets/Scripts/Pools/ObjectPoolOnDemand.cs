using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolOnDemand<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField]
    List<T> objectsToInstantiate;

    public List<T> ObjectsToInstantiate
    {
        set
        {
            objectsToInstantiate = value;
        }
    }

    [SerializeField]
    int initialSize;

    [SerializeField]
    bool canIncrease;

    [SerializeField]
    bool setsParentToThisObject;

    Dictionary<T, List<T>> pools = new Dictionary<T, List<T>>();

    protected void Start()
    {
        InitializePool();
    }


    public void DisableAllObjects()
    {
        foreach (T key in pools.Keys)
        {
            foreach (T obj in pools[key])
            {
                obj.gameObject.SetActive(false);
            }
        }

    }

    protected void InitializePool()
    {
        foreach (T obj in objectsToInstantiate)
        {
            for (int i = 0; i < initialSize; i++)
            {
                InstantiateObject(obj);
            }
        }
    }

    protected T InstantiateObject(T toInstantiate)
    {
        T obj = setsParentToThisObject ? Instantiate(toInstantiate, transform) : Instantiate(toInstantiate);
        obj.gameObject.SetActive(false);

        if (!pools.ContainsKey(toInstantiate))
        {
            pools.Add(toInstantiate, new List<T>());
        }
        pools[toInstantiate].Add(obj);

        return obj;
    }

    /// <summary>
    /// Returns an inactive object, if objects are available.
    /// </summary>
    /// <returns></returns>
    public T GetObject(T toInstantiate)
    {
        if (!pools.ContainsKey(toInstantiate))
        {
            if (!canIncrease)
            {
                return null;
            }
            return InstantiateObject(toInstantiate);
        }




        foreach (T obj in pools[toInstantiate])
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

        return InstantiateObject(toInstantiate);
    }
}
