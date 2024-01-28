using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;
    private void OnTriggerEnter(Collider other)
    {
        _gameManager._titleScreen.OnVictory();
    }
}
