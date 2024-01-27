using System;
using UnityEngine;
[RequireComponent(typeof(InputReader))]
public class CharacterMovement : MonoBehaviour
{
    private readonly float GRAVITY_VALUE = -9.81f;
    
    [SerializeField] 
    private InputReader _inputReader;
    [SerializeField] 
    private Camera _cam;
    [SerializeField] 
    private CharacterController _controller;

    [SerializeField] 
    private float _speed;

    private void OnEnable()
    {
        _inputReader.MovementEvent += ProcessMovement;
    }

    private void OnDisable()
    {
        _inputReader.MovementEvent -= ProcessMovement;
    }
    
    private void ProcessMovement(Vector2 movementInput)
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection = _cam.transform.forward * movementInput.y + _cam.transform.right * movementInput.x;
        moveDirection.y = GRAVITY_VALUE/_speed;
        var motion = (moveDirection) * _speed * Time.deltaTime;
        _controller.Move(motion);
    }

    private void OnApplicationFocus(bool hasFocus)
    {
        Cursor.visible = false;
    }
}
