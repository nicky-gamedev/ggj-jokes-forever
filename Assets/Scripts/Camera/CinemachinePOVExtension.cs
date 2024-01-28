using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CinemachinePOVExtension : CinemachineExtension
{
    [SerializeField] 
    private InputReader _inputReader;
    
    [SerializeField] 
    private float _minimumRotation;
    [SerializeField] 
    private float _maximumRotation;
    [SerializeField] 
    private float _horizontalSpeed;
    [SerializeField] 
    private float _verticalSpeed;

    private Vector3 _currentLookDirection;
    private Vector2 _inputLookDirection;
    
    protected override void OnEnable()
    {
        _inputReader.LookEvent += OnLookInput;    
        base.OnEnable();
    }

    private void OnDisable()
    {
        _inputReader.LookEvent -= OnLookInput;    
    }

    protected override void Awake()
    {
        _currentLookDirection = transform.localRotation.eulerAngles;
        base.Awake();
    }
    private void Start()
    {
        AudioManager.Instance.PlayLoop("theme_song", 1);
    }

    public void Update()
    {
        Cursor.visible = false;
    }

    protected override void PostPipelineStageCallback(CinemachineVirtualCameraBase vcam, CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
    {
        if (vcam.Follow && stage == CinemachineCore.Stage.Aim)
        {
            _currentLookDirection.x += _inputLookDirection.x * _verticalSpeed* Time.deltaTime;
            _currentLookDirection.y += _inputLookDirection.y * _horizontalSpeed * Time.deltaTime;
            _currentLookDirection.y = Mathf.Clamp(_currentLookDirection.y, _minimumRotation, _maximumRotation);
            state.RawOrientation = Quaternion.Euler(-_currentLookDirection.y, _currentLookDirection.x, 0f);
        }
    }

    private void OnLookInput(Vector2 lookInput)
    {
        _inputLookDirection = lookInput;
    }
}
