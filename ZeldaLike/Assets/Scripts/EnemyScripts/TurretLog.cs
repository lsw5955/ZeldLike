using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretLog : Log
{
    public GameObject projectile;

    public float fireDelay;
    private float fireDelaySeconds;
    private bool canFire;

    private void Update()
    {
        fireDelaySeconds -= Time.deltaTime;
        if(fireDelaySeconds <=0)
        {
            canFire = true;
            fireDelaySeconds = fireDelay;
        }
    }

    public override void CheckDistance()
    {
        //Debug.Log("监测距离 : " + Vector3.Distance(target.position, transform.position));
        if (Vector3.Distance(target.position, transform.position) <= chaseRaidus && Vector3.Distance(target.position, transform.position) >= attackRaidus)
        {
            //Debug.Log("进入追击范围, 此时敌人状态 : " + currentState);
            if (currentState == EnemyState.walk || currentState == EnemyState.idle || currentState != EnemyState.stagger)
            {
                if(canFire)
                {

                    Vector3 tempVector = target.transform.position - transform.position ;
                    GameObject current = Instantiate(projectile, transform.position, Quaternion.identity);
                    current.GetComponent<Projectile>().Launch(tempVector);
                    canFire = false;
                    ChangerState(EnemyState.walk);
                    anim.SetBool("wakeup", true);
                }
            }
        }
        else if (Vector3.Distance(target.position, transform.position) > chaseRaidus)
        {
            anim.SetBool("wakeup", false);
        }
    }
}
