using System;
using UnityEngine;
using UnityEngine.Events;

public class Shop : MonoBehaviour
{
    public UnityEvent PlayerTrigger;
    public UnityEvent PlayerTriggerExit;
    private GameObject _shopPopUpCanvas;
    private bool _canOpenShop;

    private void Awake()
    {
        _shopPopUpCanvas = GetComponentInChildren<Canvas>().gameObject;
        _shopPopUpCanvas.SetActive(false);
    }

    private void Update()
    {
        //Doing this in Update as doing it in TriggerStay it didnt register sometimes.
        if (_canOpenShop == true && Input.GetKeyDown(KeyCode.E))
        {
            PlayerTrigger.Invoke();
            CanOpenShop(false);
            _shopPopUpCanvas.SetActive(false);
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the player as entered the trigger.
        if (other.GetComponent<PlayerController>() == true)
        {
            CanOpenShop(true);
            _shopPopUpCanvas.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        //Check if the player has exited the trigger
        if (other.GetComponent<PlayerController>() == true)
        {
            CanOpenShop(false);
            PlayerTriggerExit.Invoke();
            _shopPopUpCanvas.SetActive(false);
        }
    }

    public void CanOpenShop(bool value)
    {
        _canOpenShop = value;
    }
}