using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolLog : Log
{
    void CheckDistance()
    {
        //Debug.Log("监测距离 : " + Vector3.Distance(target.position, transform.position));
        if (Vector3.Distance(target.position, transform.position) <= chaseRaidus && Vector3.Distance(target.position, transform.position) >= attackRaidus)
        {
            //Debug.Log("进入追击范围, 此时敌人状态 : " + currentState);
            if (currentState == EnemyState.walk || currentState == EnemyState.idle || currentState != EnemyState.stagger)
            {
                Vector3 temp = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
                changeAnim(temp - transform.position);
                myRigibody.MovePosition(temp);
                //ChangerState(EnemyState.walk);
                anim.SetBool("wakeup", true);
            }
        }
        else if (Vector3.Distance(target.position, transform.position) > chaseRaidus)
        {

        }
    }
}
