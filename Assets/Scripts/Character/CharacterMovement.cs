using System;
using UnityEngine;
[RequireComponent(typeof(InputReader))]
public class CharacterMovement : MonoBehaviour
{
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
        _inputReader.Init();
        _inputReader.MovementEvent += ProcessMovement;
        
    }

    private void OnDisable()
    {
        _inputReader.MovementEvent -= ProcessMovement;
    }

    private void Start()
    {
        Cursor.visible = false;
    }

    private void ProcessMovement(Vector2 movementInput)
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = movementInput.x;
        moveDirection.z = movementInput.y;
        moveDirection = _cam.transform.forward * moveDirection.z + _cam.transform.right * movementInput.x;
        var motion = (moveDirection) * _speed * Time.deltaTime;
        
        _controller.Move(motion);
    }
}
