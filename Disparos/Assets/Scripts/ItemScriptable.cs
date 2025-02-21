using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Item",menuName ="ScriptableObjects/Items")]
public class ItemScriptable : ScriptableObject
{
    public string Itemname;
    public float damage;
    public int cost;
    public string rarity;
}
