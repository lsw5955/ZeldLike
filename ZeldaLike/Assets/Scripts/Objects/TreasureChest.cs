using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TreasureChest : Interactable
{
    public Item content;
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

            }
            else
            {

            }
        }
    }

    public void OpenChest()
    {

    }

    public void ChestAlreadyOpen()
    {

    }
}
