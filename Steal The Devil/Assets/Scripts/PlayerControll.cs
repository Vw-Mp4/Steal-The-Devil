using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{
    public float horizontalInput;
    public float verticalInput;
    public float speed;
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
        Vector3 direction = new Vector3(horizontalInput, 0, verticalInput);
        transform.Translate(direction * Time.deltaTime * speed);

        /*if (Input.GetKey(KeyCode.LeftShift))
        {
            source = GetComponent<Cinemachine.CinemachineImpulseSource>();
            source.GenerateImpulse(Camera.main.transform.forward);
        }*/ // <------------------ ISSO É PRA DEPOIS.  
    }
}
