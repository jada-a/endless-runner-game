using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField]
    internal PlayerController player;

    [SerializeField]
    internal Animator anim;

    [SerializeField]
    internal Transform attackPoint;

    [SerializeField]
    internal float attackRange = 0.5f;

    [SerializeField]
    internal LayerMask enemyLayers;

    [SerializeField]
    internal int attackDamage = 1;

    [SerializeField]
    internal float attackRate = 2f;

    float nextAttackTime = 0f;

    private void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (player.inputScript.isAttackPressed)
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
       
    }

    void Attack()
    {
        //Play an attack animation
        anim.SetTrigger("Attack");

       Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
