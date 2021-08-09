using System;
using UnityEngine;

public class InvetoryButtonManager : MonoBehaviour
{
    [HideInInspector] public ItemObject ItemObject;
    [HideInInspector] private PlayerData _playerData;
    public AudioClip _buttonClickAudioClip;
    private AudioManager _audioManager;

    private void Awake()
    {
        _audioManager = FindObjectOfType<AudioManager>();
        _playerData = Resources.Load<PlayerData>("ScriptableData/Data/PlayerData");
        if (_playerData == null)
        {
            Debug.LogWarning("PlayerData is Null");
        }
    }

    public void OnClick()
    {
        if (ItemObject == null) return;
        var button = GetComponentInParent<InvetoryItem>();

        if (button.buttonType == InvetoryItem.ButtonType.Buy)
        {
            if (ItemObject.ItemObj.Price > _playerData.Money) return;
            ShopMenuManager.UpdateList(ItemObject, true);
            _playerData.Money -= ItemObject.ItemObj.Price;
            Destroy(this.gameObject.transform.parent.gameObject);
        }
        else if (button.buttonType == InvetoryItem.ButtonType.Sell)
        {
            ShopMenuManager.UpdateList(ItemObject, false);
            _playerData.Money += ItemObject.ItemObj.Price;
            Destroy(this.gameObject.transform.parent.gameObject);
        }
        else if (button.buttonType == InvetoryItem.ButtonType.Bag)
        {
            PlayerController.ChangeVisualTO(ItemObject);
            transform.parent.parent.parent.gameObject.SetActive(false);
        }

        _audioManager.PlayOneShot(_buttonClickAudioClip);
    }
}