using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace KeySystem
{
    public class KeyRaycast : MonoBehaviour
    {
        [SerializeField] private int rayLength = 5;
        [SerializeField] private LayerMask layerMaskInteract;
        [SerializeField] private string exclusiveLayerName = null;

        private KeyItemController raycastedObject;
        [SerializeField] private KeyCode openDoorKey = KeyCode.Mouse0;
        [SerializeField] private Image crosshair = null;

        private bool isCrossHairActive;
        private bool doOnce;

        private string interactableTag = "InteractiveObject";

        private void Update()
        {
            RaycastHit hit;
            Vector3 fwd = transform.TransformDirection(Vector3.forward);
            int mask = 1 << LayerMask.NameToLayer(exclusiveLayerName) | layerMaskInteract.value;
            
            if(Physics.Raycast(transform.position, fwd, out hit, rayLength, mask))
            {
                if(hit.collider.CompareTag(interactableTag))
                {
                    if(!doOnce)
                    {
                        raycastedObject = hit.collider.gameObject.GetComponent<KeyItemController>();
                        CrossHairChange(true);
                    }
                    isCrossHairActive = true;
                    doOnce = true;
                    
                    if(Input.GetKeyDown(openDoorKey))
                    {
                        raycastedObject.ObjectInteraction();
                    }
                }
            }
            else
            {
               if(isCrossHairActive)
               {
                    CrossHairChange(false);
                    doOnce = false;

               }
            }
        
        }

        void CrossHairChange(bool on)
        {
            if(on && !doOnce)
            {
                crosshair.color = Color.red;
            }
            else
            {
                crosshair.color = Color.white;
                isCrossHairActive = false;
            }
        }

    }
}

