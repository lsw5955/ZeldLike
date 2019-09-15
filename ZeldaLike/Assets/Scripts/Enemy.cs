using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState
{
    idle,
    attack,
    stagger,
    walk
}

public class Enemy : MonoBehaviour
{

    public EnemyState currentState;
    public string enemyName;
    public int health;
    public int baseAttack;
    public float moveSpeed;

    public void Knock(Rigidbody2D myRigidbody, float knockTime)
    {
        StartCoroutine(KnockCo(myRigidbody, knockTime));
    }

    private IEnumerator KnockCo(Rigidbody2D myRigidbody,float knockTime)
    {
        if(myRigidbody != null)
        { 
            yield return new WaitForSeconds(knockTime);
            myRigidbody.velocity = Vector2.zero;
            myRigidbody.GetComponent<Enemy>().currentState = EnemyState.idle;
            /*start 自己加的 模拟log击退后再回来*
            log.moveSpeed = enemyMoveSpeed;
            *end 自己加的 模拟log击退后再回来*/
            //enemy.isKinematic = true;
        }
    }
}
