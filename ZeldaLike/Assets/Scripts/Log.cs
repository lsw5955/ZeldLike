﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Log : Enemy
{
    public Rigidbody2D myRigibody;

    public Transform target;
    public float chaseRaidus;
    public float attackRaidus;
    public Transform homePosition;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        currentState = EnemyState.idle;
        myRigibody = GetComponent<Rigidbody2D>();
        target = GameObject.FindWithTag("Player").transform;
    }
    
    private void changeAnim(Vector2 direction)
    {
        if(Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            if(direction.x >0)
            {
                anim.SetFloat("moveX", 1);
            }
            else
            {
                anim.SetFloat("moveX", -1);
            }
        }
        else if (Mathf.Abs(direction.x) < Mathf.Abs(direction.y))
        {
            if (direction.y > 0)
            {
                anim.SetFloat("moveY", 1);
            }
            else
            {
                anim.SetFloat("moveY", -1);
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CheckDistance();
    }

    void CheckDistance()
    {
        //Debug.Log("监测距离 : " + Vector3.Distance(target.position, transform.position));
        if(Vector3.Distance(target.position,transform.position) <= chaseRaidus && Vector3.Distance(target.position, transform.position) >= attackRaidus)
        {
            //Debug.Log("进入追击范围, 此时敌人状态 : " + currentState);
            if (currentState == EnemyState.walk || currentState == EnemyState.idle || currentState != EnemyState.stagger)
            {
                Vector3 temp = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
                changeAnim(temp - transform.position);
                myRigibody.MovePosition(temp);
                ChangerState(EnemyState.walk);
                anim.SetBool("wakeup", true);
            }
        }
        else if (Vector3.Distance(target.position, transform.position) > chaseRaidus)
        {
            anim.SetBool("wakeup", false);
        }
    }

    private void ChangerState(EnemyState newState)
    {
        if(currentState != newState)
        {
            currentState = newState;
        }
    }
}
