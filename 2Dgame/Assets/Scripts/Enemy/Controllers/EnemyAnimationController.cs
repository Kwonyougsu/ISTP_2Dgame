using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class EnemyAnimationController : MonoBehaviour
{
    private Animator animator;
    private EnemyController controller;
    private EnemyHealthSystem healthSystem;
    private static readonly int IsMoving = Animator.StringToHash("IsMoving");
    private static readonly int IsHit = Animator.StringToHash("IsHit");
    private readonly float magnituteThreshold = 0.5f;


    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        controller = GetComponent<EnemyController>();
        healthSystem = GetComponent<EnemyHealthSystem>();

    }

    private void Start()
    {
        controller.OnMoveEvent += Move;
        healthSystem.OnDamage += Hit;
        healthSystem.OnInvincibilityEnd += InvincibilityEnd;
    }

    private void Move(Vector2 obj)
    {
        animator.SetBool(IsMoving, obj.magnitude > magnituteThreshold);
    }

    private void Hit()
    {   
        animator.SetBool(IsHit, true);
    }

    private void InvincibilityEnd()
    {
        animator.SetBool(IsHit, false);
    }

}
