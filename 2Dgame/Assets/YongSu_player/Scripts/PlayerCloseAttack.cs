using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCloseAttack : MonoBehaviour
{
    [SerializeField] private float damege;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject attack = collision.gameObject;


        if (attack.CompareTag("Enemy"))
        {
            attack.GetComponent<EnemyHealthSystem>().ChangeHealth(-damege);
            attack.GetComponent<EnemyMovement>().ApplyKnockback(transform, 2f, 0.3f);
        }
    }
}
