using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
[System.Serializable]
public class BoolValue : ScriptableObject
{ 
    [Header("Value running in game")]
    public bool initialValue;

    [Header("Value by default when starting")]
    public bool defaultValue;
}
