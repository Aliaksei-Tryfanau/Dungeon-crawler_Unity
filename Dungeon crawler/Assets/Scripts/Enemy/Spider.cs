using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy, IDamageable
{
    public GameObject acidEffect;
    public int Health { get; set; }

    public override void Init()
    {
        Health = health;
        base.Init();
    }

    public override void Update()
    {
        
    }

    public void Damage()
    {
        Health--;
        if (Health < 1)
        {
            isDead = true;
            anim.SetTrigger("Death");
        }
    }

    public override void Movement()
    {

    }

    public void Attack()
    {
        Instantiate(acidEffect, transform.position, Quaternion.identity);
    }
}