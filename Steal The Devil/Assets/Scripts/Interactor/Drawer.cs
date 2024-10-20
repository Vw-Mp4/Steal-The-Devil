using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawer : MonoBehaviour, IInteractable
{

    [SerializeField] string _prompt;
    public GameObject drawer1;
    public Animator drawerAnim1;

    public string InteractionPrompt => _prompt;

    // Start is called before the first frame update
    void Awake()
    {    
        drawerAnim1 = GetComponent<Animator>();
    }

    // Update is called once per frame
    public bool Interact(Interactor interactor)
    {
        drawerAnim1.SetBool("isOpening", true);
        return true;
    }
}
