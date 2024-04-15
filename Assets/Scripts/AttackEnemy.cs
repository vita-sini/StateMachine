using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AttackEnemy : MonoBehaviour
{
    [SerializeField] private int _damage;

    private Animator _animator;

    //private float attackRange = 2f;

    private LayerMask targetLayer;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
            _animator.Play("Attack1");
        player._health.ApplyDamage(_damage);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
            _animator.StopPlayback();
    }
}
