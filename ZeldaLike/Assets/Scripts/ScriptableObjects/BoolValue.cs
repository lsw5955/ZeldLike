using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class BoolValue : ScriptableObject, ISerializationCallbackReceiver
{
    [Header("Value running in game")]
    public bool initialValue;

    [Header("Value by default when starting")]
    public bool defaultValue;

    public void OnBeforeSerialize()
    {
    }
    public void OnAfterDeserialize()
    {
        //Debug.Log("我反序列化了");
        initialValue = defaultValue;
    }
}
