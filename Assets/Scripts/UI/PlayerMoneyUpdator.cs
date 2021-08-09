using System;
using TMPro;
using UnityEngine;

public class PlayerMoneyUpdator : MonoBehaviour
{
    private PlayerData _playerData;
    private int _playerMoney;
    private TMP_Text _playerMoneyText;

    private void OnEnable()
    {
        _playerData = Resources.Load<PlayerData>("ScriptableData/Data/PlayerData");
        if (_playerData == null)
        {
            Debug.LogWarning("PlayerData is Null");
        }

        _playerMoneyText = GetComponent<TMP_Text>();
    }

    private void Update()
    {
        if (_playerMoney != _playerData.Money)
        {
            _playerMoney = _playerData.Money;
            _playerMoneyText.text = _playerMoney.ToString();
        }
    }
}