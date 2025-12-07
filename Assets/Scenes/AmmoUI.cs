using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AmmoUI : MonoBehaviour
{
    public TMP_Text ammoText;
    public GunSwitcher gunSwitcher; // assign in Inspector

    void Update()
    {
        if (ammoText == null || gunSwitcher == null) return;

        GameObject gun = gunSwitcher.GetCurrentWeapon();
        if (gun == null) return;

        Gun gunScript = gun.GetComponent<Gun>();
        Rifle rifleScript = gun.GetComponent<Rifle>();

        if (gunScript != null)
            ammoText.text = $"{gunScript.currentMagAmmo} / {AmmoManager.Instance.pistolAmmo}";
        else if (rifleScript != null)
            ammoText.text = $"{rifleScript.currentMagAmmo} / {AmmoManager.Instance.rifleAmmo}";
    }
}
