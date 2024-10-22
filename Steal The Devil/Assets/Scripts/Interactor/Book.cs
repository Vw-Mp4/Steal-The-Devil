using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    public GameObject livro;
    

    public string InteractionPrompt => _prompt;

    void Start()
    {
        livro = GameObject.FindGameObjectWithTag("livro");
        
    }
    public bool Interact(Interactor interactor)
    {
        
        return true;
    }
}
