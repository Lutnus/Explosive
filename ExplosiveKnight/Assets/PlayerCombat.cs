using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))

        {

            Attack();


        }
    }

    void Attack()
    {
        //play anim
        animator.SetTrigger("Attack");
        //detect enemys
        Collider2D[] hitenemies = Physics2D.OverlapCircleAll(attackPoint.position ,attackRange, enemyLayers);
        //damage them
        foreach(Collider2D enemy in hitenemies)
        {
            Debug.Log("I hit " + enemy.name);


        }

            }

}
