using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundedNPC : sign
{
    private Vector3 directionVector;
    public float speed;
    private Rigidbody2D myRigidbody;
    private Animator anim;
    public Collider2D bounds;

    private bool isMoving;
    public float moveTime;
    private float moveTimeSeconds;
    public float waitTime;
    private float waitTimeSeconds;

    private void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        ChangeDirection();

        moveTimeSeconds = moveTime;
        waitTimeSeconds = waitTime;
    }

    protected override void Update()
    {
        base.Update();
        if(!playerInRange)
        {
            if (isMoving)
            {
                Move();
                moveTimeSeconds -= Time.deltaTime;
                if (moveTimeSeconds <= 0)
                {
                    moveTimeSeconds = moveTime;
                    isMoving = false;
                }
            }
            else
            {
                waitTimeSeconds -= Time.deltaTime;
                if (waitTimeSeconds <= 0)
                {
                    ChoseNewDirection();
                    waitTimeSeconds = waitTime;
                    isMoving = true;
                }
            }
        }
    }

    void Move()
    {
        
        Vector3 temp = transform.position + directionVector * speed * Time.deltaTime;
        if (bounds.bounds.Contains(temp))
        {
            myRigidbody.MovePosition(temp);
        }
        else
        {
            ChangeDirection();
        }
    }

    void ChangeDirection()
    {
        int direction = Random.Range(0, 4);
        switch(direction)
        {
            case 0:
                directionVector = Vector3.right;
                break;
            case 1:
                directionVector = Vector3.up;
                break;
            case 2:
                directionVector = Vector3.left;
                break;
            case 3:
                directionVector = Vector3.down;
                break;
            default:
                break;
        }

        UpdateAnimation();
    }

    void UpdateAnimation()
    {
        anim.SetFloat("moveX", directionVector.x);
        anim.SetFloat("moveY", directionVector.y);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        ChoseNewDirection();
    }

    private void ChoseNewDirection()
    {
        Vector3 temp = directionVector;
        int loops = 0;
        ChangeDirection();
        while (temp == directionVector && loops < 100)
        {
            loops++;
            ChangeDirection();
        }
    }
}
