using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Attack
{
    [SerializeField] private int _damage;

    private Animator _animator;
    
    public float attackRange = 2f;

    private Player _player;

    public void AttackPlayer()
    {
        _animator.Play("Attack1");
        _player._health.ApplyDamage(_damage);
    }
}