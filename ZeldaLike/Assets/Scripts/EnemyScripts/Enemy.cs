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
    [Header("State Machine")]
    public EnemyState currentState;

    [Header("Enemy Stats")]
    public string enemyName;
    public FloatValue maxHealth;
    public float health;
    public int baseAttack;
    public float moveSpeed;

    [Header("Death Effect")]
    public GameObject deathEffect;
    private float deathEffectDelay = 1f;

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
            DeathEffect();
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

    private void DeathEffect()
    {
        if(deathEffect != null)
        {
            GameObject effect = GameObject.Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(effect, deathEffectDelay);
        }
    }
}
