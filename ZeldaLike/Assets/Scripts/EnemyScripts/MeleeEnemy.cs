using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : Log
{
    public override void CheckDistance()
    {
        //Debug.Log("监测距离 : " + Vector3.Distance(target.position, transform.position));
        if (Vector3.Distance(target.position, transform.position) <= chaseRaidus && Vector3.Distance(target.position, transform.position) >= attackRaidus)
        {
            //Debug.Log("进入追击范围, 此时敌人状态 : " + currentState);
            if (currentState == EnemyState.walk || currentState == EnemyState.idle)
            {
                Vector3 temp = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
                changeAnim(temp - transform.position);
                myRigibody.MovePosition(temp);
                ChangerState(EnemyState.walk);
            }
        }
        else if (Vector3.Distance(target.position, transform.position) <= chaseRaidus && Vector3.Distance(target.position, transform.position) < attackRaidus)
        {
            if (currentState == EnemyState.walk)
            {
                StartCoroutine(AttackCo());
            }
        }
    }

    public IEnumerator AttackCo()
    {
        currentState = EnemyState.attack;
        anim.SetBool("attack", true);
        yield return new WaitForSeconds(0.5f);
        currentState = EnemyState.walk;
        anim.SetBool("attack", false);
    }
}
