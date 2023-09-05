using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName ="SO/SOData")]
public class Scriptable : ScriptableObject
{
    public string itemName;
    public GameObject item;
    public float damage;

    [TextArea(10, 20)]public string description;
}
