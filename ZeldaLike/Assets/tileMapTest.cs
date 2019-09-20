using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class tileMapTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("大小是 : "+this.GetComponent<Tilemap>().size);   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
