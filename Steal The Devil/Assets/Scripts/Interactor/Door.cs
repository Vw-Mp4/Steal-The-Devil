using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    [SerializeField] public string _prompt;

    public string InteractionPrompt => _prompt;
    public Animator portaAnimPog;
    public GameObject porta;

    void Start()
    {
        porta = GameObject.FindGameObjectWithTag("porta");
        portaAnimPog = porta.GetComponent<Animator>();   
    }
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
            portaAnimPog.SetBool("isOpening", true);
            return true;
        }
        Debug.Log("cade a chave viado");
        return false;
        
    }
}
