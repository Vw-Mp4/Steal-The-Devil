using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomNumberGeneratorTESTE : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        Debug.Log(Random.Range(0, 100));
        Destroy(gameObject);
    }
}
