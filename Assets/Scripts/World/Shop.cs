using System;
using UnityEngine;
using UnityEngine.Events;

public class Shop : MonoBehaviour
{
    public UnityEvent PlayerTrigger;
    public UnityEvent PlayerTriggerExit;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerController>() == true)
        {
            PlayerTrigger.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<PlayerController>() == true)
        {
            PlayerTriggerExit.Invoke();
        }
    }
}