using System;
using System.Collections.Generic;
using UnityEngine;

public class ScreenManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> _screensReferences;
    
    private Dictionary<Type, IUIScreen> _cachedScreenInstance = new();
    private Queue<IUIScreen> _screenQueue = new();
    private IUIScreen m_currentQueuedScreen;

    private void Awake()
    {
        SetScreensToCache();
    }

    private void SetScreensToCache()
    {
        foreach (var screenObject in _screensReferences)
        {
            IUIScreen screenInstance = screenObject.GetComponent<IUIScreen>();
            Type screenType = screenInstance.GetType();
            _cachedScreenInstance[screenType] = screenInstance;
            screenInstance.Init(screenType);
        }
    }
    public T GetScreen<T>() where T : IUIScreen
    {
        if (!_cachedScreenInstance.ContainsKey(typeof(T)))
        {
            Debug.LogError("Add screen to the stack");
        }
        return (T)_cachedScreenInstance[typeof(T)];
    }
}
