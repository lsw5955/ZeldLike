using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MagicManager : MonoBehaviour
{
    public Slider magicSlider;
    public Inventory playerInventory;

    // Start is called before the first frame update
    void Start()
    {
        magicSlider.maxValue = playerInventory.maxMagic;
        magicSlider.value = magicSlider.maxValue;
        playerInventory.currentMagic = magicSlider.maxValue;
    }

    public void AddMagic()
    {
        magicSlider.value = playerInventory.currentMagic;
    }

    public void DecreaseMagic()
    {
        magicSlider.value = playerInventory.currentMagic;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
