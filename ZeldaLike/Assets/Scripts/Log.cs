using System.Collections;
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
    }

    // Update is called once per frame
    void Update()
    {
        CheckDistance();
    }

    void CheckDistance()
    {
        Debug.Log(Vector3.Distance(target.position, transform.position));
        if(Vector3.Distance(target.position,transform.position) <= chaseRaidus && Vector3.Distance(target.position, transform.position) >= attackRaidus)
        {
            Vector3 temp = Vector3.MoveTowards(transform.position, target.position, moveSpeed*Time.deltaTime);

            myRigibody.MovePosition(temp);
        }
    }
}
