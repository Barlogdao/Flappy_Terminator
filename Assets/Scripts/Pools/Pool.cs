using System.Collections.Generic;
using UnityEngine;

public abstract class Pool<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] private  Transform _container;
    [SerializeField] private T _objectPrefab;

    private  Queue<T> _pool;

    private void Awake()
    {
        _pool = new Queue<T>();
    }

    public T GetObjet()
    {
        if (_pool.Count == 0)
        {
            T poolObject = Instantiate(_objectPrefab, _container);
            OnCreateObject(poolObject);

            return poolObject;
        }

        return _pool.Dequeue();
    }

    public void PutObject(T poolObject)
    {
        _pool.Enqueue(poolObject);
        poolObject.gameObject.SetActive(false);
    }

    public void Reset()
    {
        foreach (Transform transform in _container)
        {
            if (transform.TryGetComponent(out T poolObject))
            {
                PutObject(poolObject);
            }
        }
    }

    protected abstract void OnCreateObject(T poolObject);
}
