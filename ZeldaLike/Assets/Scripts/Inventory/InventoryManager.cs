using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    [Header("Inventory Information")]
    public PlayerInventory playerInventory;
    [SerializeField]
    private GameObject blankInventorySlot;
    [SerializeField]
    private GameObject inventoryPanel;
    [SerializeField]
    private Text descriptionText;
    [SerializeField]
    private GameObject useButton;
    public InventoryItem currentItem;
    
    void MakeInventorySlots()
    {
        if(playerInventory)
        {
            for(int i = 0; i< playerInventory.myInventory.Count;i++)
            {
                GameObject temp = Instantiate(blankInventorySlot, inventoryPanel.transform.position, Quaternion.identity);
                temp.transform.SetParent(inventoryPanel.transform);

                InventorySlot newSlot = temp.GetComponent<InventorySlot>();
                if(newSlot)
                {
                    newSlot.Setup(playerInventory.myInventory[i], this);
                }
            }
        }
    }

    public void SetTextAndButton(string description, bool buttonActive)
    {
        descriptionText.text = description;
        useButton.SetActive(buttonActive);
    }

    // Start is called before the first frame update
    void OnEnable()
    {
        ClearInventorySlots();
        MakeInventorySlots();
        SetTextAndButton("", false);  
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetupDescriptionAndButton(string newDescriptiongString,bool isButtonUsable,InventoryItem newItem)
    {
        currentItem = newItem;
        descriptionText.text = newDescriptiongString;
        useButton.SetActive(isButtonUsable);
    }

    public void UseButtonPressed()
    {
        currentItem.Use();
        ClearInventorySlots();
        MakeInventorySlots();
    }

    void ClearInventorySlots()
    {
        for(int i = 0; i < inventoryPanel.transform.childCount;i++)
        {
            Destroy(inventoryPanel.transform.GetChild(i).gameObject);        
        }
    }
}
