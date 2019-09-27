using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolLog : Log
{
    public Transform[] path;
    public int currentPoint;
    public Transform currentGoal;
    public float roundingDistance;

    public override void CheckDistance()
    {
        if (Vector3.Distance(target.position, transform.position) <= chaseRaidus && Vector3.Distance(target.position, transform.position) >= attackRaidus)
        {
            if (currentState == EnemyState.walk || currentState == EnemyState.idle || currentState != EnemyState.stagger)
            {
                Vector3 temp = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
                changeAnim(temp - transform.position);
                myRigibody.MovePosition(temp);
                anim.SetBool("wakeup", true);
            }
        }
        else if (Vector3.Distance(target.position, transform.position) > chaseRaidus)
        {
            if(Vector3.Distance(transform.position, path[currentPoint].position) > roundingDistance)
            {
                Vector3 temp = Vector3.MoveTowards(transform.position, path[currentPoint].position, moveSpeed * Time.deltaTime);
                changeAnim(path[currentPoint].position - transform.position);
                myRigibody.MovePosition(temp);
            }
            else
            {
                ChangeGoal();
            }
            
        }
    }

    private void ChangeGoal()
    {
        if(currentPoint == path.Length -1)
        {
            currentPoint = 0;
            currentGoal = path[currentPoint];
        }
        else
        {
            currentPoint++;
            currentGoal = path[currentPoint];
        }
    }
}
