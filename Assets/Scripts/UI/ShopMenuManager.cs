using System;
using TMPro;
using UnityEngine;

public class ShopMenuManager : MonoBehaviour
{
    private ItemList _itemList;

    [SerializeField] private GameObject _button;

    public static Action<ItemObject, bool> UpdateList;

    public enum MenuType
    {
        Buy,
        Sell
    };

    public MenuType menuType;

    private void Awake()
    {
        _itemList = Resources.Load<ItemList>(menuType == MenuType.Buy
            ? "ScriptableData/Lists/ShopList"
            : "ScriptableData/Lists/PlayerList");

        CreateMenu();
        UpdateList += UpdateMenu;
    }

    /// <summary>
    /// Updates Shop Menu when called
    /// </summary>
    /// <param name="item">Item Object</param>
    /// <param name="buy"> true if buy button</param>
    private void UpdateMenu(ItemObject item, bool buy)
    {
        if (buy == true)
        {
            if (menuType == MenuType.Buy)
            {
                _itemList.Items.Remove(item);
            }
            else
            {
                _itemList.Items.Add(item);
                CreateShopItem(item);
            }
        }
        else
        {
            if (menuType == MenuType.Buy)
            {
                _itemList.Items.Add(item);
                CreateShopItem(item);
            }
            else
            {
                _itemList.Items.Remove(item);
            }
        }
    }

    /// <summary>
    ///For Each item on the List Create a button
    /// </summary>
    private void CreateMenu()
    {
        foreach (var item in _itemList.Items)
        {
            CreateShopItem(item);
        }
    }

    /// <summary>
    /// Instantiates a Shop Item as a child of the this object and sets all the data required by the Button Manager. 
    /// </summary>
    /// <param name="item"></param>
    private void CreateShopItem(ItemObject item)
    {
        if (item.ItemObj.Name == "White Shirt") return;
        var InvetoryObject = Instantiate(_button, this.transform);
        InvetoryObject.name = item.ItemObj.Name;
        var inItem = InvetoryObject.GetComponentInChildren<InvetoryItem>();
        inItem.ItemName = item.ItemObj.Name;
        inItem.ItemImage = item.ItemObj.Image;
        inItem.ItemPrice = item.ItemObj.Price.ToString();

        InvetoryObject.GetComponentInChildren<InvetoryButtonManager>().ItemObject = item;
    }

    /// <summary>
    /// Go through all the child transform and delete it if its an inventory item.
    /// </summary>
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