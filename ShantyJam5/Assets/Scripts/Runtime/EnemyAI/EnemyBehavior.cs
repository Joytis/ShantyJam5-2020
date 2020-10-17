﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
#region Public Variables
    public float attackDistance; // Minimum distance for attack

    public float moveSpeed;

    public float timer; // Timer for cooldown between attacks

    public Transform leftLimit;

    public Transform rightLimit;

    [HideInInspector]
    public Transform target;

    [HideInInspector]
    public bool inRange;

    public GameObject hotZone;

    public GameObject triggerArea;
#endregion



#region Private Variables
    private Animator anim;

    private float distance; // Stores distance b/w Enemy and Player

    private bool attackMode;

    private bool cooling; // Check if Enemy is in cooldown after attack

    private float intTimer;
#endregion


    void Awake()
    {
        SelectTarget();
        intTimer = timer; // Store the initial value of timer
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!attackMode)
        {
            Move();
        }

        if (
            !InsideofLimits() &&
            !inRange &&
            !anim.GetCurrentAnimatorStateInfo(0).IsName("Attack.anim")
        )
        {
            SelectTarget();
        }

        if (inRange)
        {
            EnemyLogic();
        }
    }

    void EnemyLogic()
    {
        distance = Vector2.Distance(transform.position, target.position);

        if (distance > attackDistance)
        {
            StopAttack();
        }
        else if (attackDistance >= distance && cooling == false)
        {
            Attack();
        }

        if (cooling)
        {
            Cooldown();
            anim.SetBool("canAttack", false);
        }
    }

    // Enemy Move Functions
    void Move()
    {
        anim.SetBool("canWalk", true);
        print("Moving!");
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Attack.anim"))
        {
            Vector2 targetPosition =
                new Vector2(target.position.x, transform.position.y);

            transform.position =
                Vector2
                    .MoveTowards(transform.position,
                    targetPosition,
                    moveSpeed * Time.deltaTime);
        }
    }

    void Attack()
    {
        timer = intTimer; // Reset Timer when Player enter Attack Range
        attackMode = true; // To check if Enemy can still attack or not

        print("Attacking!");
        anim.SetBool("canWalk", false);
        anim.SetBool("canAttack", true);
    }

    void Cooldown()
    {
        timer -= Time.deltaTime;

        if (timer <= 0 && cooling && attackMode)
        {
            cooling = false;
            timer = intTimer; // Reset timer to initial value
        }
    }

    void StopAttack()
    {
        // Stops attacking when out of range.
        cooling = false;
        attackMode = false;
        print("Stop Attack!");
        anim.SetBool("canAttack", false);
    }

    public void TriggerCooling()
    {
        cooling = true;
    }

    private bool InsideofLimits()
    {
        return transform.position.x > leftLimit.position.x &&
        transform.position.x < rightLimit.position.x;
    }

    public void SelectTarget()
    {
        float distanceToLeft =
            Vector2.Distance(transform.position, leftLimit.position);
        float distanceToRight =
            Vector2.Distance(transform.position, rightLimit.position);

        if (distanceToLeft > distanceToRight)
        {
            target = leftLimit;
        }
        else
        {
            target = rightLimit;
        }

        Flip();
    }

    public void Flip()
    {
        Vector3 rotation = transform.eulerAngles;
        if (transform.position.x > target.position.x)
        {
            rotation.y = 0f;
        }
        else
        {
            rotation.y = 180f;
        }

        transform.eulerAngles = rotation;
    }
}