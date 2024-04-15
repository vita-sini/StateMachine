using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecoveryHealth : MonoBehaviour
{
    [SerializeField] private int _health;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            Destroy(gameObject);
            player._health.Healing(_health);
        }
    }
}
