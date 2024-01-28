using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Newtonsoft.Json;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class DialogScreen : UIScreen<DialogController>
{
    private readonly string DIALOG_SCREEN_KEY = "dialogScreen";
    private readonly string DIALOG_DATA_PATH = "/Dialog/DialogData.json";
    public override string Key => DIALOG_SCREEN_KEY;

    [SerializeField] 
    private TextMeshProUGUI _dialogText;
    [SerializeField] 
    private Image _avatarImage;

    private Coroutine _dialogRoutine;
    private List<DialogData> _currentDialog = new();
    private int _currentDialogStep;
    public override void Init<T>(T controller)
    {
        GetDialogData();
        base.Init(controller);
    }

    public void ShowDialogNarrativeDialog(string narrativeKey)
    {
        var dialog = Controller.GetNarrativeDialog(narrativeKey, _currentDialogStep);
        if (dialog != null)
        {
            if (_dialogRoutine != null)
            {
                StopCoroutine(_dialogRoutine);
            }
            HideDialog();
            _currentDialog = dialog;
            ShowDialog();
        }
    }

    public void ShowCharacterRandomDialog()
    {
        if (!Controller.HasActiveDialog())
        {
            if (_dialogRoutine != null)
            {
                StopCoroutine(_dialogRoutine);
            }
            _currentDialogStep = 0;
            _currentDialog = Controller.GetRandomDialog();
            ShowDialog();
        }
    }

    private void ShowDialog()
    {
        Controller.SetDialog(_currentDialog);
        _dialogText.text = _currentDialog[_currentDialogStep].Text;
        _dialogRoutine ??= StartCoroutine(DialogTimeAlive());
    }

    private void HideDialog()
    {
        Controller.CompleteDialog(_currentDialog);
        _currentDialogStep = 0;
        _currentDialog.Clear();
        _dialogText.text = string.Empty;
        _dialogRoutine = null;
        Controller.SetDialog(_currentDialog);
    }

    private IEnumerator DialogTimeAlive()
    {
        yield return new WaitForSeconds(_currentDialog[_currentDialogStep].AppearTime);
        var nextDialog = Controller.TryGetNextDialog(_currentDialog[_currentDialogStep].Key, _currentDialogStep);
        _dialogRoutine = null;
        if (nextDialog != null)
        {
            _currentDialogStep++;
            ShowDialog();
        }
        else
        {
            HideDialog();
        }
    }
    
    private void GetDialogData()
    {
        var jsonPath = Application.streamingAssetsPath + DIALOG_DATA_PATH;
        StartCoroutine(LoadJsonFile(jsonPath));
    }
    
    private IEnumerator LoadJsonFile(string url)
    {
        UnityWebRequest request = UnityWebRequest.Get(url);
        yield return request.SendWebRequest();
        
        while (!request.isDone)
        {
            yield return true;
        }
        
        if (request.result == UnityWebRequest.Result.ConnectionError)
        {
            Debug.LogError("Error to dowload json");
            yield break;
        }
        Controller.SetupDialogData(JsonConvert.DeserializeObject<List<DialogData>>(request.downloadHandler.text));
    }
}
