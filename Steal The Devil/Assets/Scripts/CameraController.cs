using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    
    public Transform targetForCamera;
    public float pLerp;
    public float rLerp;

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, targetForCamera.position, pLerp);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetForCamera.rotation, rLerp);
        

    }
}
