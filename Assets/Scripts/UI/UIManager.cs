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
    private bool _canOpenPauseMenu;

    private void Awake()
    {
        // Using FindObjectOfType as a quick way to get this Components.
        // As this is a prototype and its done in Awake it should be fine but
        // This is not recommend. 
        _playerController = FindObjectOfType<PlayerController>();
        Time.timeScale = 0f;
        CanOpenPauseMenu(false);
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

        if (Input.GetKeyDown(KeyCode.P) && _canOpenPauseMenu == true)
        {
            OnPausePress.Invoke();
        }
    }

    /// <summary>
    /// Sets The Time Scale
    /// </summary>
    /// <param name="scale">scale Value</param>
    public void SetTimeScale(float scale)
    {
        Time.timeScale = scale;
    }

    /// <summary>
    /// Quit the Game/Application
    /// </summary>
    public void ExitApplication()
    {
        Application.Quit();
    }

    /// <summary>
    /// Set if Inventory menu can be showed or not.
    /// </summary>
    /// <param name="value"> bool value</param>
    public void ShowInventoryMenu(bool value)
    {
        _invetoryMenu.SetActive(value);
        CanPlayerMove(!value);
    }

    /// <summary>
    /// sets if the player can move or not. Call Can Move function on the Player Controller 
    /// </summary>
    /// <param name="value">bool Value</param>
    public void CanPlayerMove(bool value)
    {
        _playerController.CanPlayerMove(value);
    }

    /// <summary>
    /// Set if can open inventory.  
    /// </summary>
    /// <param name="value"></param>
    public void CanOpenInventory(bool value)
    {
        _canOpenInventory = value;
    }

    public void CanOpenPauseMenu(bool value)
    {
        _canOpenPauseMenu = value;
    }
}