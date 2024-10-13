using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.ShaderGraph.Internal.KeywordDependentCollection;

public class Inventory : MonoBehaviour
{
    public bool hasKey = false;
    public bool chestOpen = false;
    public float raycastDistance = 2.0f;
    public float radiusDistance = 3.0f;
    public float circusDistanece = 2.0f;
    float forceMagnitude = 1f;
    public GameObject chave;
    public GameObject armario;
    Animator animator;

    private void Awake()
    {
        chave = GameObject.FindGameObjectWithTag("chave");
        armario = GameObject.FindGameObjectWithTag("armario");
        chestOpen = !chestOpen;
    }
    private void Update()
    {
        //Se eu apertar Q, vou ter a chave.
        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, raycastDistance))
            {
                if (hit.collider.gameObject == chave)
                {
                    Destroy(chave);
                    hasKey = !hasKey;
                    Debug.DrawLine(transform.position, transform.forward);
                }
            }
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody rigidbody = hit.collider.attachedRigidbody;
        if (rigidbody != null)
        {
            
                Vector3 forceDirection = hit.gameObject.transform.position - transform.position;
                forceDirection.y = 0;
                forceDirection.z = 0;
                forceDirection.Normalize();

                rigidbody.AddForceAtPosition(forceDirection * forceMagnitude, transform.position, ForceMode.Impulse);
            
            
        }
    }
}