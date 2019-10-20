using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{    
    public bool playerInRange;
    public Signaler context;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            //Debug.Log("进入了饿啊 我碰到了" + other + ", 它" + other.transform.position);
            context.Raise();
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            //Debug.Log("退出了饿啊 我是" + other);
            context.Raise();
            playerInRange = false;
        }
    }
}
