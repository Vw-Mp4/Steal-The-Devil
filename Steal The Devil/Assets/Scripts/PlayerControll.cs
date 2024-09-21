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
    public Animator animController;
    

    Cinemachine.CinemachineImpulseSource source;

    // Start is called before the first frame update
    void Start()
    {
        animController = GetComponent<Animator>();
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
        
        if (direction == Vector3.zero)
        {
            animController.SetFloat("isRunning", 0);
        }
        else if(direction == Vector3.forward)
        {
            animController.SetFloat("isRunning", 1);
        }
        if (direction.x == 0)
        {
            animController.SetFloat("Right", 0);
            animController.SetFloat("Left", 0);
        }
        else if(direction == Vector3.right)
        {
            animController.SetFloat("Right", 1);
        }
        if(direction == Vector3.left) 
        {
            animController.SetFloat("Left", 1);
        }
       
          
    }

    private void LateUpdate()
    {
        transform.Rotate(Vector3.up * rotationValue * mouseX);
    }
}
