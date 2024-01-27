using System;
using UnityEngine;

public interface IUIScreen
{
    public string Key { get; }
    CanvasGroup CanvasGroup { get; }

    public void Init<T>(T controller);
    public void StartShow();
    public void StartHide();
    public bool IsShowing();
}