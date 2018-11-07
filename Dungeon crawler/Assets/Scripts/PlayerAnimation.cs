using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    Animator _animator;

    void Start()
    {
        _animator = GetComponentInChildren<Animator>();
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
}
