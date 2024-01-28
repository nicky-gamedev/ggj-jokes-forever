using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

public enum DialogType
{
    Narrative,
    Protagonist_Random
}

public class DialogController : IScreenController
{
    private List<DialogData> _dialogData = new();
    private readonly Dictionary<string, List<DialogData>> _dialogsByKey = new();
    private readonly Dictionary<string, List<DialogData>> _dialogsByType = new();
    private readonly HashSet<string> _narrativeDialogRead = new();
    private List<DialogData> _currentDialog = new();
    private int _currentDialogCurrentStep;
    private int _currentDialogStepNumber;
    
    public void SetupDialogData(List<DialogData> data)
    {
        _dialogData = data;
        ProcessDialogsByKey();
        ProcessDialogsByType();
    }

    private void ProcessDialogsByKey()
    {
        foreach (var dialog in _dialogData)
        {
            if (_dialogsByKey.ContainsKey(dialog.Key))
            {
                _dialogsByKey[dialog.Key].Add(dialog);
                continue;
            }
            _dialogsByKey[dialog.Key] = new List<DialogData>{ dialog };
        }
    }

    private void ProcessDialogsByType()
    {
        foreach (var dialog in _dialogData)
        {
            if (_dialogsByType.TryGetValue(dialog.Type, out var dialogList))
            {
                dialogList.Add(dialog);
                continue;
            }
            _dialogsByType[dialog.Type] = new List<DialogData>{ dialog };
        }
    }

    public List<DialogData> GetNarrativeDialog(string dialogKey, int currentStep)
    {
        Debug.Log(currentStep);
        bool _isDialogAlreadyRead = _narrativeDialogRead.Contains(dialogKey);
        bool _isTheSameDialogKey = _currentDialog.Count > 0 && _currentDialog[currentStep].Key == _dialogsByKey[dialogKey][currentStep].Key;
        if (_isDialogAlreadyRead ||  _isTheSameDialogKey)
        {
            return null;
        }
        return _dialogsByKey[dialogKey];
    }

    public List<DialogData> GetRandomDialog()
    {
        int randomDialogChosen = Random.Range(0, _dialogsByType[DialogType.Protagonist_Random.ToString()].Count);
        string dialogKey =  _dialogsByType[DialogType.Protagonist_Random.ToString()][randomDialogChosen].Key;
        var dialogData = _dialogsByKey[dialogKey];
        return dialogData;
    }

    public DialogData TryGetNextDialog(string key, int currentDialogStep)
    {
        return currentDialogStep+1 < _dialogsByKey[key].Count ? _dialogsByKey[key][currentDialogStep] : null;
    }

    public void CompleteDialog(List<DialogData> dialogs)
    {
        foreach (var dialog in dialogs)
        {
            if (dialog.Type != DialogType.Protagonist_Random.ToString())
            {
                _narrativeDialogRead.Add(dialog.Key);
            }
        }
    }

    public void SetDialog(List<DialogData> dialog)
    {
        _currentDialog = dialog;
    }
    

    public bool HasActiveDialog()
    {
        return _currentDialog.Count > 0;
    }

    public bool HasNarrativeDialogActive(int currentDialogStep)
    {
        return _currentDialog[currentDialogStep].Type == DialogType.Narrative.ToString();
    }
}
