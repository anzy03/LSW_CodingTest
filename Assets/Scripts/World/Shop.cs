using System;
using UnityEngine;
using UnityEngine.Events;

public class Shop : MonoBehaviour
{
    public UnityEvent PlayerTrigger;
    public UnityEvent PlayerTriggerExit;
    private GameObject _shopPopUpCanvas;
    private bool _hasPlayerEnter;
    private UIManager _uiManager;

    private void Awake()
    {
        // Using FindObjectOfType as a quick way to get this Components.
        // As this is a prototype and its done in Awake it should be fine but
        // This is not recommend. 
        _uiManager = FindObjectOfType<UIManager>();

        _shopPopUpCanvas = GetComponentInChildren<Canvas>().gameObject;
        _shopPopUpCanvas.SetActive(false);
    }

    private void Update()
    {
        //Doing this in Update as doing it in TriggerStay it didnt register sometimes.
        if (_hasPlayerEnter == true && Input.GetKeyDown(KeyCode.E))
        {
            _uiManager.CanOpenInventory(false);
            PlayerTrigger.Invoke();
            _hasPlayerEnter = false;
            _shopPopUpCanvas.SetActive(false);
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the player as entered the trigger.
        if (other.GetComponent<PlayerController>() == true)
        {
            _hasPlayerEnter = true;
            _shopPopUpCanvas.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        //Check if the player has exited the trigger
        if (other.GetComponent<PlayerController>() == true)
        {
            _hasPlayerEnter = false;
            PlayerTriggerExit.Invoke();
            _shopPopUpCanvas.SetActive(false);
            _uiManager.CanOpenInventory(true);
        }
    }
}