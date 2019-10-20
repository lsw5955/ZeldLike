using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Loot
{
    public Powerup thisLoot;
    public int lootChance;
}

[CreateAssetMenu]
public class LootTable : ScriptableObject
{
    public Loot[] loots;

    public Powerup LootPower()
    {
        int sumChance = 0;
        int currentChance = Random.Range(0, 100);

        foreach(Loot p in loots)
        {
            sumChance +=  p.lootChance;
            if(sumChance >= currentChance)
            {
                return p.thisLoot;
            }
        }

        return null;
    }
}
