using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicHealthReaction : MonoBehaviour
{
    public Inventory playerInventory;
    public Signaler magicSignal;
    
    public void Use(int amountToIncrease)
    {
        playerInventory.currentMagic = playerInventory.maxMagic < (playerInventory.currentMagic + amountToIncrease) ? playerInventory.maxMagic:playerInventory.currentMagic + amountToIncrease;
        magicSignal.Raise();
    }
}
