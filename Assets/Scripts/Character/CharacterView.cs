using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterView : MonoBehaviour
{
    [SerializeField] 
    private Animator _animator;
    [SerializeField] 
    private ClownPistol _weapon;
    [SerializeField] 
    private InputReader _inputReader;
    
    private void OnEnable()
    {
        _weapon.OnShootAttack += UpdateShootAnimation;
        _weapon.OnMeeleAttack += UpdateMeeleAnimation;
        _inputReader.MovementEvent += UpdateMovement;
    }

    private void OnDisable()
    {
        _weapon.OnShootAttack -= UpdateShootAnimation;
        _weapon.OnMeeleAttack -= UpdateMeeleAnimation;
    }

    private void UpdateShootAnimation()
    {
        _animator.SetTrigger("Shoot");
    }

    private void UpdateMovement(Vector2 direction)
    {
        _animator.SetFloat("Velocity", direction.magnitude);
    }

    private void UpdateMeeleAnimation()
    {
        _animator.SetTrigger("Punch");
    }
}
