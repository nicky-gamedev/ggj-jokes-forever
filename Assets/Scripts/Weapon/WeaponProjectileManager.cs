using System;
using UnityEngine;

public class WeaponProjectileManager : MonoBehaviour
{
    private GameObjectPool _objectPool;
    private int _damage;
    [SerializeField] private GameObject _projectilePrefab;
    [SerializeField] private int defaultSize;
    [SerializeField] private int maxSize;
    [SerializeField] private Vector3 offset;
    [SerializeField] private GameObject _shootParticle;



    private void Awake()
    {
        _objectPool = new GameObjectPool(_projectilePrefab, defaultSize, maxSize);
    }

    public void SetDamage(int amount)
    {
        _damage = amount;
    }

    public void CreateProjectile(Vector3 forward, Vector3 position)
    {
        WeaponProjectile projectile = _objectPool.Get().GetComponent<WeaponProjectile>();
        projectile.Init(forward, position, offset);
        projectile.OnProjectileHit += obj =>
        {
            if (projectile.gameObject.activeSelf)
                _objectPool.Release(projectile.gameObject);
            if (obj.TryGetComponent(out Health health))
            {
                var particleObj = Instantiate(_shootParticle, obj.transform.position, Quaternion.identity);
                Destroy(particleObj.gameObject,0.5f);
                health.SubtractHealth(_damage);
            }
        };
    }
    
}