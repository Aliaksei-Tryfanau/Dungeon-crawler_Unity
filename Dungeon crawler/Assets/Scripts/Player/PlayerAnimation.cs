using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator _animator;
    private Animator _swordAnimation;

    void Start()
    {
        _animator = GetComponentInChildren<Animator>();
        _swordAnimation = transform.GetChild(1).GetComponent<Animator>();
    }

    void Update()
    {

    }

    public void Move(float move)
    {
        _animator.SetFloat("Move", move);
    }

    public void Jump(bool jumping)
    {
        _animator.SetBool("Jumping", jumping);
    }

    public void Attack()
    {
        _animator.SetTrigger("Attack");
        _swordAnimation.SetTrigger("SwordAnimation");
    }
}
