using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Inventory",menuName = "Inventory/New Inventory")]
public class Inventory : ScriptableObject
{
    //背包系統&商店系統
    public List<Item> itemList = new List<Item>();




}
