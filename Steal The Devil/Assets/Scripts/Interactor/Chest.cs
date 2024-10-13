using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    public GameObject bau;
    public Animator chestAnim;

    public string InteractionPrompt => _prompt;

    void Start()
    {
        bau = GameObject.FindGameObjectWithTag("bau");
        chestAnim = bau.GetComponent<Animator>();
    }
    public bool Interact(Interactor interactor)
    {
        Debug.Log("eu sou gay");
        chestAnim.SetBool("chestOpening", true);
        return true;
    }
}
