using System;
using UnityEngine;

public class Shop : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerController>() == true)
        {
            Debug.Log("PlayerDetected");
            //TODO start buying prompt
        }
    }
}