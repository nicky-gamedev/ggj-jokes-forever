using UnityEngine;
using System;
public abstract class UIScreen<T> : MonoBehaviour, IUIScreen where T: IScreenController, new()
{
    public abstract string Key { get;}
    public CanvasGroup CanvasGroup { get; private set; }
    protected T Controller { get; set; }
    private Action OnShowCompletedCallback { get; set; }

    public void Init<T>(T controller)
    {
        CanvasGroup = GetComponent<CanvasGroup>();
        Controller = new();
    }

    public void Show(T controller, Action onShowCompletedCallback = null)
    {
        Controller = controller;
        OnShowCompletedCallback = onShowCompletedCallback;
        StartShow();
    }
    
    public void StartShow()
    {
        Debug.Log($"Mostrando {Key}");
        Debug.Log($"Controller is {Controller.GetType()}");
    }
    

    public void StartHide()
    {
    }

    public bool IsShowing()
    {
        return false;
    }
}
