using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InvetoryItem : MonoBehaviour
{
    // This Script is mainly to pass on value to each Inventory item when Creating it.
    [HideInInspector]
    public string ItemName
    {
        // Set the Name Text on UI when changing the Item Name.
        set => GO_ItemName.text = value;
    }

    [HideInInspector]
    public string ItemPrice
    {
        // Set the Price Text on UI when changing the Item Price.
        set => GO_ItemPrice.text = value;
    }

    [HideInInspector]
    public Sprite ItemImage
    {
        // Set the Price Image on UI when changing the Item Image.
        set => GO_ItemImage.overrideSprite = value;
    }

    [SerializeField] private TMP_Text GO_ItemName;
    [SerializeField] private Image GO_ItemImage;
    [SerializeField] private TMP_Text GO_ItemPrice;

    // ButtonType Emun to determine finality when clicking it.
    public enum ButtonType
    {
        Buy,
        Sell,
        Bag
    };

    public ButtonType buttonType;
}