using System;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private ItemList _playerInventory;
    [SerializeField] private GameObject _inventoryGameObject;

    private void OnEnable()
    {
        foreach (var item in _playerInventory.Items)
        {
            CreateButton(item);
        }
    }

    private void OnDisable()
    {
        DeleteMenu();
    }

    private void CreateButton(ItemObject item)
    {
        var InvetoryObject = Instantiate(_inventoryGameObject, this.transform);
        InvetoryObject.name = item.ItemObj.Name;
        var inItem = InvetoryObject.GetComponentInChildren<InvetoryItem>();
        inItem.ItemName = item.ItemObj.Name;
        inItem.ItemImage = item.ItemObj.Image;

        InvetoryObject.GetComponentInChildren<InvetoryButtonManager>().ItemObject = item;
    }

    private void DeleteMenu()
    {
        foreach (Transform child in transform)
        {
            if (child.GetComponent<InvetoryItem>() == true)
            {
                Destroy(child.gameObject);
            }
        }
    }
}