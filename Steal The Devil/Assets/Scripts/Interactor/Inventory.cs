using JetBrains.Annotations;
using StarterAssets;
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
    float forceMagnitude = 10f;
    public GameObject chave;
    public GameObject armario;
    public GameObject livro;
    public Animator animator;
    public StarterAssetsInputs starterAssetsInputs;
    public Interactor interactor;
    private ThirdPersonController thirdPersonController;
    public float radius = 3.0f;
    

    private void Awake()
    {
        livro = GameObject.FindGameObjectWithTag("livro");
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
                if (hit.collider.gameObject == livro)
                {
                    Debug.Log("Est� lendo livro");
                }

            }
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody rigidbody = hit.collider.attachedRigidbody;
        if (rigidbody != null && hit.collider.gameObject == armario)
        {
            Vector3 forceDirection = hit.gameObject.transform.position - transform.position;
            forceDirection.y = 0;
            forceDirection.z = 0;
            forceDirection.Normalize();
            
            if (starterAssetsInputs.move.y > 0 && starterAssetsInputs.sprint == true)
            {
                starterAssetsInputs.cursorInputForLook = false;
                starterAssetsInputs.move.x *= 0;
                animator.SetTrigger("isPushing");
                rigidbody.AddForceAtPosition(forceDirection * forceMagnitude, transform.position, ForceMode.Impulse);
            }
            else if ((starterAssetsInputs.move.y == 0 || starterAssetsInputs.sprint == false))
            {
                animator.ResetTrigger("isPushing");
                starterAssetsInputs.cursorInputForLook = true;
                
            }
            
        }
        
    }
}