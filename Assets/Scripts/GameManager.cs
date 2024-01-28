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
        _screenManager.GetScreen<DialogScreen>().ShowCharacterRandomDialog();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
