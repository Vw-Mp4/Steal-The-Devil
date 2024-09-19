using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{
    public float horizontalInput;
    public float verticalInput;
    public float mouseX;
    public float mouseY;
    public float speed;
    public float rotationValue;
    

    Cinemachine.CinemachineImpulseSource source;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");
        Vector3 direction = new Vector3(horizontalInput, 0, verticalInput);
        transform.Translate(direction * Time.deltaTime * speed);
        

        /*if (Input.GetKey(KeyCode.LeftShift))
        {
            source = GetComponent<Cinemachine.CinemachineImpulseSource>();
            source.GenerateImpulse(Camera.main.transform.forward);
        }*/ // <------------------ ISSO É PRA DEPOIS.  
    }

    private void LateUpdate()
    {
        transform.Rotate(Vector3.up * rotationValue * mouseX * Time.deltaTime);
    }
}
