using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log(this.gameObject.name + "我触发了");
        if(other.CompareTag("breakable"))
        {
            other.GetComponent<pot>().smash();
        }
    }
}
