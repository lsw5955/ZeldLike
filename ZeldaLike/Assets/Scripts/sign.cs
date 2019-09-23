using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sign : MonoBehaviour
{
    public GameObject dialogBox;
    public Text dialogTxt;
    public string dialog;
    public bool playerInRange;
    public Signaler contextClueOn;
    public Signaler contextClueOff;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.E) && playerInRange)
        {
            if(dialogBox.activeInHierarchy)
            {
                dialogBox.SetActive(false);
            }
            else
            {
                dialogBox.SetActive(true);
                dialogTxt.text = dialog; 
            }
        }        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            contextClueOn.Raise();
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            playerInRange = false;
            dialogBox.SetActive(false);
        }
    }
}
