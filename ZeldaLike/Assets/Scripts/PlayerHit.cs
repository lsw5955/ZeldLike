using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(this.gameObject.name + "触发碰撞监测了");
        if(other.CompareTag("breakable"))
        {
            other.GetComponent<pot>().smash();
        }
    }
}
