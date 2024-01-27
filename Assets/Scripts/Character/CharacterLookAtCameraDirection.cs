using System;
using UnityEngine;

public class CharacterLookAtCameraDirection : MonoBehaviour
{
    [SerializeField] 
    private Camera _cam;
    
    private void Update()
    {
        ProcessLook();
    }

    private void ProcessLook()
    {
        transform.rotation = Quaternion.LookRotation(_cam.transform.forward, _cam.transform.up);
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
    }
}
