using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillboardLookAtCamera : MonoBehaviour
{
    private Camera _camera;
    
    void Start()
    {
        _camera = Camera.main;
    }
    
    void Update()
    {
        transform.LookAt(_camera.transform.position);
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
    }
}
