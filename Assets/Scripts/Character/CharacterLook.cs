using UnityEngine;

public class CharacterLook : MonoBehaviour
{
    [SerializeField] 
    private Camera _cam;
    [SerializeField] 
    private InputReader _inputReader;

    [SerializeField] 
    private float _xSensitivity;
    [SerializeField] 
    private float _ySensitivity;

    [SerializeField] 
    private float _minimumRotation;
    [SerializeField] 
    private float _maximumRotation;

    private float _currentXRotation;

    private void OnEnable()
    {
        _inputReader.LookEvent += ProcessLook;
    }

    private void OnDisable()
    {
        _inputReader.LookEvent -= ProcessLook;
    }

    private void ProcessLook(Vector2 lookInput)
    {
        float mouseX = lookInput.x;
        float mouseY = lookInput.y;
        _currentXRotation -= (mouseY * Time.deltaTime) * _ySensitivity;
        _currentXRotation = Mathf.Clamp(_currentXRotation, _minimumRotation, _maximumRotation);
        _cam.transform.localRotation = Quaternion.Euler(_currentXRotation, 0, 0);
        transform.Rotate(Vector3.up * (mouseX * Time.deltaTime) * _xSensitivity);
    }
}
