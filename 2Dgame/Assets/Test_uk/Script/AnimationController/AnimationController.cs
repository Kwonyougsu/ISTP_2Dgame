using UnityEngine;

public class AnimationController : MonoBehaviour
{
    protected Animator animator;
    protected PlayerInputController controller;

    protected virtual void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        controller = GetComponent<PlayerInputController>();
    }
}
