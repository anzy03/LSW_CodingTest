using System;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject _invetoryMenu;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            _invetoryMenu.SetActive(_invetoryMenu.activeSelf == false);
        }
    }
}