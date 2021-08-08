using System;
using UnityEngine;

public class InvetoryButtonManager : MonoBehaviour
{
    [HideInInspector] public ItemObject ItemObject;

    public void OnClick()
    {
        if (ItemObject == null) return;
        var button = GetComponentInParent<InvetoryItem>();

        if (button.buttonType == InvetoryItem.ButtonType.Buy)
        {
            InventoryMenu.UpdateList(ItemObject, true);
            Destroy(this.gameObject.transform.parent.gameObject);
        }
        else if (button.buttonType == InvetoryItem.ButtonType.Sell)
        {
            InventoryMenu.UpdateList(ItemObject, false);
            Destroy(this.gameObject.transform.parent.gameObject);
        }
        else if (button.buttonType == InvetoryItem.ButtonType.Bag)
        {
            PlayerController.ChangeVisualTO(ItemObject);
        }
    }
}