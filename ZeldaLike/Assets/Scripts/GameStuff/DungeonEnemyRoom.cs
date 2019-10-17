using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonEnemyRoom : DungeonRoom
{
    public Door[] doors;

    public void CloseDoors()
    {
        foreach(Door d in doors)
        {
            d.Close();
        }
    }

    public void OpenDoors()
    {
        foreach (Door d in doors)
        {
            d.Open();
        }
    }

    public void CheckEnemies()
    {
        foreach(Enemy e in enemies)
        {
            if(e.gameObject.activeInHierarchy)
            {
                return;
            }
        }

        OpenDoors();
    }


    public override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            foreach (Enemy em in enemies)
            {
                ChangeActivation(em, true);
            }

            foreach (pot p in pots)
            {
                ChangeActivation(p, true);
            }
        }

        CloseDoors(); 
    }

    public override void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            foreach (Enemy em in enemies)
            {
                ChangeActivation(em, false);
            }

            foreach (pot p in pots)
            {
                ChangeActivation(p, false);
            }
        }
    }
}
