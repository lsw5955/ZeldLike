using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : Powerup
{
    public FloatValue playerHealth;
    public FloatValue HeartContainers;
    public float amountToIncrease;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && !other.isTrigger)
        {
            playerHealth.runtimeValue += amountToIncrease;
            if(playerHealth.runtimeValue > HeartContainers.runtimeValue *2)
            {
                playerHealth.runtimeValue = HeartContainers.runtimeValue * 2;
            }
            powerupSignal.Raise();
            Destroy(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
