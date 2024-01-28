using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _amount;
    public int Amount => _amount;
    public event Action OnHealthDepleted = delegate {};
    
    
    public event Action OnHealthReduced;
    public void AddHealth(int amount)
    {
        _amount += amount;
    }

    public void SubtractHealth(int amount)
    {
        _amount -= amount;
        OnHealthReduced?.Invoke();
    }

    private void Update()
    {
        if (_amount <= 0)
        {
            OnHealthDepleted();
        }
    }
}