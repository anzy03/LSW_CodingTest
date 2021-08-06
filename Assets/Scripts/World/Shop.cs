using System;
using UnityEngine;

public class Shop : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerController>() == true)
        {
            //TODO start buying prompt
        }
    }
}