using System;
using UnityEngine;
using UnityEngine.Events;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject _invetoryMenu;

    public UnityEvent OnEscPress;
    public UnityEvent OnPausePress;
    private PlayerData _playerData;

    private void Awake()
    {
        Time.timeScale = 0f;
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            _invetoryMenu.SetActive(_invetoryMenu.activeSelf == false);
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
}