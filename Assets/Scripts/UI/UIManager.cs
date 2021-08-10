using System;
using UnityEngine;
using UnityEngine.Events;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject _invetoryMenu;

    public UnityEvent OnEscPress;
    public UnityEvent OnPausePress;
    private PlayerData _playerData;
    private PlayerController _playerController;
    private bool _canOpenInventory;

    private void Awake()
    {
        _playerController = FindObjectOfType<PlayerController>();
        Time.timeScale = 0f;
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I) && _canOpenInventory == true)
        {
            ShowInventoryMenu(_invetoryMenu.activeSelf == false);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OnEscPress.Invoke();
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            OnPausePress.Invoke();
        }
    }

    public void SetTimeScale(float scale)
    {
        Time.timeScale = scale;
    }

    public void ExitApplication()
    {
        Application.Quit();
    }

    public void ShowInventoryMenu(bool value)
    {
        _invetoryMenu.SetActive(value);
        CanPlayerMove(!value);
    }

    public void CanPlayerMove(bool value)
    {
        _playerController.CanPlayerMove(value);
    }

    public void CanOpenInventory(bool value)
    {
        _canOpenInventory = value;
    }
}