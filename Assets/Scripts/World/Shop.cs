using System;
using UnityEngine;
using UnityEngine.Events;

public class Shop : MonoBehaviour
{
    public UnityEvent PlayerTrigger;
    public UnityEvent PlayerTriggerExit;
    private GameObject _shopPopUpCanvas;
    private bool _hasPlayerEnter;

    private void OnEnable()
    {
        if (_shopPopUpCanvas == null)
        {
            _shopPopUpCanvas = GetComponentInChildren<Canvas>().gameObject;
        }

        _shopPopUpCanvas.SetActive(false);
    }

    private void Update()
    {
        if (_hasPlayerEnter == true && Input.GetKeyDown(KeyCode.E))
        {
            PlayerTrigger.Invoke();
            _hasPlayerEnter = false;
            _shopPopUpCanvas.SetActive(false);
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerController>() == true)
        {
            _hasPlayerEnter = true;
            _shopPopUpCanvas.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<PlayerController>() == true)
        {
            _hasPlayerEnter = false;
            PlayerTriggerExit.Invoke();
            _shopPopUpCanvas.SetActive(false);
        }
    }
}