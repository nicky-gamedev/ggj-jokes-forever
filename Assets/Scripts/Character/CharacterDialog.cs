using System;
using UnityEngine;

public class CharacterDialog : MonoBehaviour
{
    private readonly string FIRST_NARRATIVE_KEY = "Welcome_01";
    
    [SerializeField] 
    private ScreenManager _screenManager;
    [SerializeField] 
    private float _timeToSpeak;
    [SerializeField] 
    private WeaponBase _weaponBase;
    [SerializeField] private int _jokesToGainAmmo = 3;
    private int _currentJokes = 0;
    [SerializeField] private int _ammoGain = 5;
    
    private DialogScreen _dialogScreen;

    private bool _canStartTalk;
    private float _currentTimeToSpeakAgain;
    

    private void Start()
    {
        _dialogScreen = _screenManager.GetScreen<DialogScreen>();
        _dialogScreen.OnDialogCompleted += OnDialogCompleted;
    }

    public void ActivateDialog(string dialogKey)
    {
        _dialogScreen.ShowDialogNarrativeDialog(dialogKey);
    }

    
    public void AllowToTalk(bool isTalkAllowed)
    {
        _canStartTalk = isTalkAllowed;
    }

    private void ActivateRandomDialog()
    {
        _currentTimeToSpeakAgain = 0;
        _dialogScreen.ShowCharacterRandomDialog();
        _currentJokes++;
    }
    
    private void OnDialogCompleted(DialogData dialog)
    {
        if (dialog.Key == FIRST_NARRATIVE_KEY)
        {
            AllowToTalk(true);
        }
    }

    
    private void Update()
    {
        if (_canStartTalk && !_dialogScreen.IsDialogActive())
        {
            _currentTimeToSpeakAgain += Time.deltaTime;
            if (_currentTimeToSpeakAgain >= _timeToSpeak)
            {
                ActivateRandomDialog();
                
            }
        }

        if (_currentJokes <= _jokesToGainAmmo) return;
        AudioManager.Instance.PlayOneShot("laugh_1",0);
        _weaponBase.CurrentAmmo.AddAmmo(_ammoGain);
        _currentJokes = 0;
    }
    
    
}
