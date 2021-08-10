using System;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    // This Script is pretty much a duplicate with a few changes. 
    // This is not Recommended.
    [SerializeField] private ItemList _playerInventory;
    [SerializeField] private GameObject _inventoryGameObject;

    private void OnEnable()
    {
        //For Each item in the Players Inventory create a Inventory Object.
        foreach (var item in _playerInventory.Items)
        {
            CreateInventoryItem(item);
        }
    }

    private void OnDisable()
    {
        DeleteMenu();
    }

    /// <summary>
    /// Instantiates a Inventory Item as a child of the this object and sets all the data required. 
    /// </summary>
    /// <param name="item"></param>
    private void CreateInventoryItem(ItemObject item)
    {
        var InvetoryObject = Instantiate(_inventoryGameObject, this.transform);
        InvetoryObject.name = item.ItemObj.Name;
        var inItem = InvetoryObject.GetComponentInChildren<InvetoryItem>();
        inItem.ItemName = item.ItemObj.Name;
        inItem.ItemImage = item.ItemObj.Image;
        InvetoryObject.GetComponentInChildren<InvetoryButtonManager>().ItemObject = item;
    }

    /// <summary>
    /// Go through all the child transform and delete it if its an inventory item.
    /// </summary>
    private void DeleteMenu()
    {
        foreach (Transform child in transform)
        {
            // This check is not necessary right now but doing it just to be extra careful.
            if (child.GetComponent<InvetoryItem>() == true)
            {
                Destroy(child.gameObject);
            }
        }
    }
}