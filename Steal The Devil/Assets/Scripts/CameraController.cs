using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public GameObject targetForCamera;
    public float rotationPowerX;
    public float rotationPowerY;

    // Update is called once per frame
    void Update()
    {
        rotationPowerX = Input.GetAxis("Mouse X");
        rotationPowerY = Input.GetAxis("Mouse Y");
        targetForCamera.transform.rotation *= Quaternion.AngleAxis(transform.rotation.x * (rotationPowerX * -7), Vector3.up);
        targetForCamera.transform.rotation *= Quaternion.AngleAxis(transform.rotation.y * rotationPowerY, Vector3.right);
        var angles = targetForCamera.transform.localEulerAngles;
        angles.z = 0;
        var angle = targetForCamera.transform.localEulerAngles.x;

        /*if (angle > 180 && angle < 340)
        {
            angles.x = 340;
        }
        if (angle < 180 && angle < 40)
        {
            angles.x = 40;
        }*/

        player.transform.rotation = Quaternion.Euler(0, targetForCamera.transform.rotation.eulerAngles.y, 0);
        targetForCamera.transform.localEulerAngles = new Vector3(angles.x, 0, 0);

    }
}
