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
    public FloatValue maxHealth;
    public float health;
    public int baseAttack;
    public float moveSpeed;

    private void Awake()
    {
        health = maxHealth.initialValue;
    }

    public void Knock(Rigidbody2D myRigidbody, float knockTime,float damage)
    {
        StartCoroutine(KnockCo(myRigidbody, knockTime));
        TakeDamage(damage);
    }

    private void TakeDamage(float damage)
    {
        health -= damage;
        if(health <= 0)
        {
            gameObject.SetActive(false);
        }
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
