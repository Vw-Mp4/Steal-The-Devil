using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;

    public string InteractionPrompt => _prompt;

    public bool Interact(Interactor interactor)
    {
        var inventory = interactor.GetComponent<Inventory>();
        if (inventory == null)
        {
            return false;
        }
        if(inventory.hasKey)
        {
            Debug.Log("eu sou muito gay");
            return true;
        }
        Debug.Log("cade a chave viado");
        return false;
        
    }
}
