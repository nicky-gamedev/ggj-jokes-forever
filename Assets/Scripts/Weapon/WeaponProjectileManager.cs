using System;
using UnityEngine;

public class WeaponProjectileManager : MonoBehaviour
{
    [SerializeField] private GameObjectPool _objectPool;
    [SerializeField] private GameObject _projectilePrefab;
    [SerializeField] private int defaultSize;
    [SerializeField] private int maxSize;
    [SerializeField] private Transform playerTransform;

    private void Awake()
    {
        _objectPool = new GameObjectPool(_projectilePrefab, defaultSize, maxSize);
    }

    public void CreateProjectile()
    {
        WeaponProjectile projectile = _objectPool.Get().GetComponent<WeaponProjectile>();
        projectile.Init(playerTransform.forward, playerTransform.position);
    }
}