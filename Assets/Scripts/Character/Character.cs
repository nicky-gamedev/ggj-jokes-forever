using System;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private CharacterInteraction _interaction;
    [SerializeField] private CharacterLookAtCameraDirection _lookAtCamera;
    [SerializeField] private CharacterMovement _movement;
    [SerializeField] private Health _health;

    private void Awake()
    {
        _health.OnHealthDepleted += (() => { Debug.Log("dead!!!!"); });
    }
}