using System;
using UnityEngine;

public class InvetoryButtonManager : MonoBehaviour
{
    [HideInInspector] public ItemObject ItemObject;
    [HideInInspector] private PlayerData _playerData;
    public AudioClip _buttonClickAudioClip;
    private AudioManager _audioManager;
    private UIManager _uiManager;
    private InvetoryItem _inventorybutton;

    private void Awake()
    {
        // Using FindObjectOfType as a quick way to get this Components.
        // As this is a prototype and its done in Awake it should be fine but
        // This is not recommend. 
        _audioManager = FindObjectOfType<AudioManager>();
        _uiManager = FindObjectOfType<UIManager>();

        _inventorybutton = GetComponentInParent<InvetoryItem>();

        _playerData = Resources.Load<PlayerData>("ScriptableData/Data/PlayerData");
        if (_playerData == null)
        {
            Debug.LogWarning("PlayerData is Null");
        }
    }

    public void OnClick()
    {
        if (ItemObject == null) return;

        // Determine which type of a button is it based on the Emum buttonType and do stuff accordingly.
        if (_inventorybutton.buttonType == InvetoryItem.ButtonType.Buy)
        {
            if (ItemObject.ItemObj.Price > _playerData.Money) return;
            ShopMenuManager.UpdateList(ItemObject, true);
            _playerData.Money -= ItemObject.ItemObj.Price;
            Destroy(this.gameObject.transform.parent.gameObject);
        }
        else if (_inventorybutton.buttonType == InvetoryItem.ButtonType.Sell)
        {
            ShopMenuManager.UpdateList(ItemObject, false);
            _playerData.Money += ItemObject.ItemObj.Price;
            Destroy(this.gameObject.transform.parent.gameObject);
        }
        else if (_inventorybutton.buttonType == InvetoryItem.ButtonType.Bag)
        {
            PlayerController.ChangeVisualTO(ItemObject);
            _uiManager.ShowInventoryMenu(false);
        }

        //Play Button Click Sound.
        _audioManager.PlayOneShot(_buttonClickAudioClip);
    }
}