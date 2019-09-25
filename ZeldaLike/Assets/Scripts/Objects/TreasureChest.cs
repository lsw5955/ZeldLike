using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TreasureChest : Interactable
{
    public Item contents;
    public Inventory playerInventory;
    public bool isOpen;
    public Signaler raiseItem;
    public GameObject dialogBox;
    public Text dialogText;
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
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

        anim.SetBool("opened", true);
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
            Debug.Log("进入了饿啊 我是" + other);
            context.Raise();
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger && !isOpen)
        {
            Debug.Log("退出了饿啊 我是" + other);
            context.Raise();
            playerInRange = false;
        }
    }

}
