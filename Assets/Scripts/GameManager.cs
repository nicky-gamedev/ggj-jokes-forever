using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] 
    private ScreenManager _screenManager;
    void Start()
    {
        _screenManager.GetScreen<DialogScreen>().Show();
    }
    
}
