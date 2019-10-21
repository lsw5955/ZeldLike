using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartContainer : Powerup
{
    public FloatValue heartContainer;
    public FloatValue playerHealth;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            heartContainer.runtimeValue += 1;
            playerHealth.runtimeValue = heartContainer.runtimeValue * 2;
            powerupSignal.Raise();
            Destroy(this.gameObject);
        }
    }
}
