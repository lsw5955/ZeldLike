using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaLog : Log
{
    public Collider2D boundary;

    public override void CheckDistance()
    {

        Debug.Log("进入领域 : " + boundary.bounds.Contains(target.transform.position));
        if (Vector3.Distance(target.position, transform.position) <= chaseRaidus && Vector3.Distance(target.position, transform.position) >= attackRaidus && boundary.bounds.Contains(target.transform.position))
        {
            
            if (currentState == EnemyState.walk || currentState == EnemyState.idle || currentState != EnemyState.stagger)
            {
                Vector3 temp = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
                changeAnim(temp - transform.position);
                myRigibody.MovePosition(temp);
                ChangerState(EnemyState.walk);
                anim.SetBool("wakeup", true);
            }
        }
        else if (Vector3.Distance(target.position, transform.position) > chaseRaidus || boundary.bounds.Contains(target.transform.position))
        {
            anim.SetBool("wakeup", false);
        }
    }

}
