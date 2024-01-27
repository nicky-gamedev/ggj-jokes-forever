using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] 
    private ScreenManager _screenManager;
    void Start()
    {
        var dialogController = new DialogController();
        _screenManager.GetScreen<DialogScreen>().Show(dialogController);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
