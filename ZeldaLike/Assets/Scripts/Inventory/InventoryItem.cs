using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "New Item",menuName = "Inventory/道具(Item)")]
public class InventoryItem : ScriptableObject
{
    public string itemName;
    public string itemDescription;
    public Sprite itemImage;
    public int numberHeld;
    public bool usable;
    public bool unique;
    public UnityEvent thisEvent;

    public void Use()
    {
        if(numberHeld > 0)
        {
            thisEvent.Invoke();
            Debug.Log(itemName + "被使用了哟.");
        }
        
    }

    public void DecreaseAmount()
    {
        numberHeld--;
        if(numberHeld<0)
        {
            numberHeld = 0;
        }
    }
}
