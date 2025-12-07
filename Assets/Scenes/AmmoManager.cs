using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoManager : MonoBehaviour
{
    public static AmmoManager Instance;

    [Header("Ammo Counts")]
    public int rifleAmmo = 60;   // reserve ammo
    public int pistolAmmo = 45;  // reserve ammo

    private void Awake()
    {
        Instance = this;
    }

    public void AddAmmo(int rifleAmount, int pistolAmount)
    {
        rifleAmmo += rifleAmount;
        pistolAmmo += pistolAmount;
    }
}
