using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HUD : MonoBehaviour
{
    [SerializeField] 
    private ClownPistol _weapon;
    [SerializeField] 
    private Health _health;
    [SerializeField] 
    private TextMeshProUGUI _ammoText;
    [SerializeField] 
    private TextMeshProUGUI _lifeText;

    private void Update()
    {
        _ammoText.text = $"Ammo\n{_weapon.CurrentAmmo.AmmoInClip}";
        _lifeText.text = $"Health\n{_health.Amount}";
    }
    
}
