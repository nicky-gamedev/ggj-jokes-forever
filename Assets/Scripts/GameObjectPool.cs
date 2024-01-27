using UnityEngine;
using UnityEngine.Pool;

public class GameObjectPool
{
    private GameObject _prefab;
    private ObjectPool<GameObject> _pool;

    public GameObjectPool(GameObject prefab, int defaultSize ,int maxSize)
    {
        _prefab = prefab;
        _pool = new ObjectPool<GameObject>(
            OnCreateGameObject,
            OnGetGameObject,
            OnReleaseGameObject,
            OnDestroyGameObject,
            true,
            defaultSize,
            maxSize);
    }

    private GameObject OnCreateGameObject()
    {
        return Object.Instantiate(_prefab);
    }

    private void OnGetGameObject(GameObject obj)
    {
        obj.SetActive(true);
    }

    private void OnReleaseGameObject(GameObject obj)
    {
        obj.SetActive(false);
    }

    private void OnDestroyGameObject(GameObject obj)
    {
        Object.Destroy(obj);
    }

    public GameObject Get(Vector3 position = default, Quaternion rotation = default)
    {
        GameObject obj = _pool.Get();
        obj.transform.SetPositionAndRotation(position, rotation);
        return obj;
    }

    public void Release(GameObject obj)
    {
        _pool.Release(obj);
    }
}