﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private string currentState = "IdleState";
    private Transform target;
    public float chaseRange = 5;
    public float attackRange = 2;
    public Animator animator;
    public float speed = 3;

    public int health;
    public int maxHealth;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerManager.gameOver)
        {
            animator.enabled = false;
            this.enabled = false;
        }
        float distance = Vector3.Distance(transform.position, target.position);

        if(currentState == "IdleState")
        {
            if (distance < chaseRange)
                currentState = "ChaseState";
        }
        else if(currentState == "ChaseState")
        {
            //play run animation
            animator.SetTrigger("chase");
            animator.SetBool("isAttacking", false);

            if(distance < attackRange)
            {
                currentState = "AttackState";
            }

            //move towards the player
            if(target.position.x > transform.position.x)
            {
                //move right
                transform.Translate(transform.right * speed *Time.deltaTime);
                transform.rotation = Quaternion.Euler(0, 180, 0);

            }
            else
            {
                //move left
                transform.Translate(-transform.right * speed * Time.deltaTime);
                transform.rotation = Quaternion.identity;
            }
        }
        else if(currentState == "AttackState")
        {
            animator.SetBool("isAttacking", true);
            if(distance > attackRange)
            {
                currentState = "ChaseState";
            }
        }

    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        currentState = "ChaseState";

        if(health < 0)
        {
            Die();
        }
    }

    private void Die()
    {
        //play death animation
        Debug.Log("enemy is dead");

        animator.SetTrigger("isDead");
        //disable the script and collider
        GetComponent<CapsuleCollider>().enabled = false;
        this.enabled = false;
    }
}
