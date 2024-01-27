using System;
using UnityEngine;

public class WeaponProjectileManager : MonoBehaviour
{
    private GameObjectPool _objectPool;
    [SerializeField] private GameObject _projectilePrefab;
    [SerializeField] private int defaultSize;
    [SerializeField] private int maxSize;
    [SerializeField] private Vector3 offset;
    [SerializeField] private WeaponBase _weaponBase;

    private void Awake()
    {
        _objectPool = new GameObjectPool(_projectilePrefab, defaultSize, maxSize);
    }

    public void CreateProjectile()
    {
        WeaponProjectile projectile = _objectPool.Get().GetComponent<WeaponProjectile>();
        projectile.Init(Camera.main.transform.forward, Camera.main.ViewportToWorldPoint(Vector3.one / 2f), offset);
        projectile.OnProjectileHit += obj =>
        {
            if (projectile.gameObject.activeSelf)
                _objectPool.Release(projectile.gameObject);
        };
    }
}