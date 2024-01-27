using System;
using UnityEngine;

public class WeaponProjectile : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float speed;
    
    public event Action<GameObject> OnProjectileHit = delegate {  };
    public void Init(Vector3 forward, Vector3 position, Vector3 offset)
    {
        transform.LookAt(forward);
        transform.position = position;
    }

    private void FixedUpdate()
    {
        rb.velocity = transform.forward * speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision other)
    {
        OnProjectileHit?.Invoke(other.gameObject);
    }
}