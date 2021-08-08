using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InvetoryItem : MonoBehaviour
{
    [HideInInspector]
    public string ItemName
    {
        set => GO_ItemName.text = value;
    }

    [HideInInspector]
    public Sprite ItemImage
    {
        set => GO_ItemImage.overrideSprite = value;
    }

    [SerializeField] private TMP_Text GO_ItemName;
    [SerializeField] private Image GO_ItemImage;

    public enum ButtonType
    {
        Buy,
        Sell,
        Bag
    };

    public ButtonType buttonType;
}