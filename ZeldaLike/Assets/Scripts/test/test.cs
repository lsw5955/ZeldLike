using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public float speed = 30;
    public Vector3 target = new Vector3(1, 0, 0);

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.D))
        {
            transform.GetComponent<Rigidbody2D>().MovePosition(transform.position + target * speed * Time.deltaTime); 
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("我撞人了");
    }

}
