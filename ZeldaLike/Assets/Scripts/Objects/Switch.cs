using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public bool active;
    public BoolValue storedValue;
    public Sprite activeSprite;
    private SpriteRenderer mySpriteRenderer;
    public Door thisDoor;


    // Start is called before the first frame update
    void Start()
    {
        active = storedValue.initialValue;
        mySpriteRenderer = GetComponent<SpriteRenderer>(); 
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && !other.isTrigger && !active)
        {
            active = true;
            storedValue.initialValue = active;
            mySpriteRenderer.sprite = activeSprite;
            thisDoor.Open();
        }
    }
}
