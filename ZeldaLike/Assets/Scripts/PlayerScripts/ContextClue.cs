using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContextClue : MonoBehaviour
{
    public GameObject contextClue;
    public bool contextActive = false;

    public void changeContext()
    {
        contextActive = !contextActive;
        Debug.Log("执行进来了, 有信号");
        if(contextActive)
        {
            Debug.Log("我设置true了啊");
            contextClue.SetActive(true);
        }
        else
        {
            contextClue.SetActive(false);
        }
    }
}
