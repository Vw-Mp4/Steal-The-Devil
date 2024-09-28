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
    public CharacterController controller;
    

    Cinemachine.CinemachineImpulseSource source;

    // Start is called before the first frame update
    void Start()
    {
        animController = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        if(verticalInput > 0)
        {
            horizontalInput = 0;
        }
        else if(horizontalInput > 0 && horizontalInput < 0)
        {
            verticalInput = 0;
        }
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");
        Vector3 direction = new Vector3(horizontalInput, 0, verticalInput);
        controller.Move(direction * Time.deltaTime * speed);

        if(direction == Vector3.zero)
        {
            animController.SetFloat("isRunning", 0);
            animController.SetFloat("isWalking", 0);
        }

        if (direction == Vector3.forward)
        {
            animController.SetFloat("isWalking", 1);
            if(Input.GetKey(KeyCode.LeftShift))
            {
                controller.Move(direction * Time.deltaTime * speed * 4);
                animController.SetFloat("isWalking", 0);
                animController.SetFloat("isRunning", 1);
            }
            else
            {
                animController.SetFloat("isRunning", 0);
                animController.SetFloat("isWalking", 1);
            }
        }
        else
        {
            animController.SetFloat("isWalking", 0);
        }

        if (direction == Vector3.back)
        {
            animController.SetFloat("isBackwards", 1);
        }
        else
        {
            animController.SetFloat("isBackwards", 0);
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
