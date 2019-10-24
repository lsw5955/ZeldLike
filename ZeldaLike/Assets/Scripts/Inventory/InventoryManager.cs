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
                    Debug.Log("我可是根红苗正!");
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
    void Start()
    {
        MakeInventorySlots();
        SetTextAndButton("", false);  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
