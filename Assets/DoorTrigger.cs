using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    private void OnTriggerEnter(Collider other)
    {
        CharacterMovement charaterMovement = null;
        if (other.TryGetComponent<CharacterMovement>(out charaterMovement))
        {
            _animator.SetBool("Open",true);
        }
    }
}
