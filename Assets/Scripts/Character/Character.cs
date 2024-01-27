using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private CharacterInteraction _interaction;
    [SerializeField] private CharacterLookAtCameraDirection _lookAtCamera;
    [SerializeField] private CharacterMovement _movement;
}