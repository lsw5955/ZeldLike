using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicHealthReaction : MonoBehaviour
{
    public FloatValue playerMagic;
    public Signaler magicSignal;
    
    public void Use(int amountToIncrease)
    {
        playerMagic.runtimeValue += amountToIncrease;
        magicSignal.Raise();
    }
}
