using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    [Header("UI stuff to change")]
    [SerializeField]
    private Image itemImange;
    [SerializeField]
    private Text itemNumberText;

    [Header("Variables from the item")]
    public InventoryItem thisItem;
    public InventoryManager thisManager;

    public void Setup(InventoryItem newItem, InventoryManager newManager)
    {
        thisItem = newItem;
        thisManager = newManager;
        if (thisItem)
        {
            Debug.Log("我执行到这里了啊");
            itemImange.sprite = thisItem.itemImage;
            itemNumberText.text = "" + thisItem.numberHeld;
        }
    }

    public void ClickedOn()
    {
        if(thisItem)
        {
            thisManager.SetupDescriptionAndButton(thisItem.itemDescription, thisItem.usable,thisItem);
        }
    }
}
