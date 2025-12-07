using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    public int rifleAmount = 30;
    public int pistolAmount = 15;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AmmoManager.Instance.AddAmmo(rifleAmount, pistolAmount);
            Destroy(gameObject);
        }
    }
}