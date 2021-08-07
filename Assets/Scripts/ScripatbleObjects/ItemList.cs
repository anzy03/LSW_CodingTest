using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Items/List")]
public class ItemList : ScriptableObject
{
    public List<ItemObject> Items;
    
}