using UnityEngine;

public class CharacterLook : MonoBehaviour
{
    // [SerializeField] 
    // private InputReader _inputReader;
    //
    // [SerializeField] 
    // private float _xSensitivity;
    // [SerializeField] 
    // private float _ySensitivity;
    //
    // [SerializeField] 
    // private float _minimumRotation;
    // [SerializeField] 
    // private float _maximumRotation;
    //
    // private float _rotation;
    //
    // private void OnEnable()
    // {
    //     _inputReader.LookEvent += ProcessLook;
    // }
    //
    // private void OnDisable()
    // {
    //     _inputReader.LookEvent -= ProcessLook;
    // }
    //
    // private float ProcessLook(Vector2 lookInput)
    // {
    //     float mouseX = lookInput.x;
    //     float mouseY = lookInput.y;
    //     _rotation -= (mouseY * Time.deltaTime) * _ySensitivity;
    //     return Mathf.Clamp(_rotation, _minimumRotation, _maximumRotation);
    //     // _cam.transform.localRotation = Quaternion.Euler(_rotation, 0, 0);
    //     // transform.Rotate(Vector3.up * (mouseX * Time.deltaTime) * _xSensitivity);
    // }
}
