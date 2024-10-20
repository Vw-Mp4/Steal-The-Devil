using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardaAnimator : MonoBehaviour
{

    private const string IS_WALKING = "IsWalking";

    [SerializeField] private Guard guard;

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();

    }

    private void Update()
    {
         //animator.SetBool(IS_WALKING, guard.IsWalking());
    }
}