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
        Debug.Log("使用物品!");
        thisEvent.Invoke();
    }
}
