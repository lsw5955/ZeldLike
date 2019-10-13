using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TreasureChest : Interactable
{
    [Header("Content")]
    public Item contents;
    public Inventory playerInventory;
    public bool isOpen;
    public BoolValue storedOpen;

    [Header("Signal and Dialog")]
    public Signaler raiseItem;
    public GameObject dialogBox;
    public Text dialogText;

    [Header("Animation")]
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        isOpen = storedOpen.initialValue;
        Debug.Log("我是" + isOpen);
        anim.SetBool("opened", isOpen);
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.E) && playerInRange )
        {
            if(!isOpen)
            {
                OpenChest();
            }
            else
            {
                ChestAlreadyOpen();
            }
        }
    }

    public void OpenChest()
    {
        //dialog window on
        dialogBox.SetActive(true);
        //dialog text = content text
        dialogText.text = contents.itemDescription;
        //add contents to the inventory
        playerInventory.AddItem(contents);
        playerInventory.currentItem = contents;
        //raise the singnal to the palyer to animate
        raiseItem.Raise();
        //raise the context clue
        context.Raise();
        //set the chest to opened
        isOpen = true;
        storedOpen.initialValue = isOpen;
        anim.SetBool("opened", isOpen);
    }

    public void ChestAlreadyOpen()
    {
        //Dialog off
        dialogBox.SetActive(false);
        //raise the singnal to player to stop animating
        raiseItem.Raise();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger && !isOpen)
        {
            //Debug.Log("进入了饿啊 我是" + other);
            context.Raise();
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger && !isOpen)
        {
            //Debug.Log("退出了饿啊 我是" + other);
            context.Raise();
            playerInRange = false;
        }
    }

}
