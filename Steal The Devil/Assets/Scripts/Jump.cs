using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    private CharacterController controller;
    public float verticalSpeed;
    public float gravityScale;
    public float jump;
    
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(controller.isGrounded)
        {
            verticalSpeed = -gravityScale * Time.deltaTime;
            if(Input.GetKeyDown(KeyCode.Space))
            {
                verticalSpeed = jump;
            }
            else
            {
                verticalSpeed -= gravityScale * Time.deltaTime;
            }
        }

        Vector3 moveVector = new Vector3(0, verticalSpeed, 0);
        controller.Move(moveVector * Time.deltaTime);   
    }
}
