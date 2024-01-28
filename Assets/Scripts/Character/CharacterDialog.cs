using System;
using UnityEngine;

public class CharacterDialog : MonoBehaviour
{
    [SerializeField] 
    private ScreenManager _screenManager;

    private DialogScreen _dialogScreen;

    private void Start()
    {
        _dialogScreen = _screenManager.GetScreen<DialogScreen>();
    }

    public void ActivateDialog(string dialogKey)
    {
        _dialogScreen.ShowDialogNarrativeDialog(dialogKey);
    }
    
    
}
