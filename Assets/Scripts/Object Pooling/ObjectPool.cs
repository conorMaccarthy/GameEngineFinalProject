using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public int poolSize = 20;
    [SerializeField] private PooledObject meteorPrefab;

    private Stack<PooledObject> objectStack;

    private void Start()
    {
        objectStack = new Stack<PooledObject>();

        PooledObject newPooledObject;

        for (int i = 0; i < poolSize; i++)
        {
            newPooledObject = Instantiate(meteorPrefab);
            newPooledObject.pool = this;
            newPooledObject.gameObject.SetActive(false);
            objectStack.Push(newPooledObject);
        }
    }

    public PooledObject GetObjectFromPool()
    {
        if (objectStack.Count == 0)
        {
            PooledObject newPooledObject = Instantiate(meteorPrefab);
            newPooledObject.pool = this;
            return newPooledObject;
        }

        PooledObject nextObject = objectStack.Pop();
        nextObject.gameObject.SetActive(true);
        return nextObject;
    }

    public void ReturnPooledObject(PooledObject pooledObject)
    {
        objectStack.Push(pooledObject);
        pooledObject.gameObject.SetActive(false);
    }
}
