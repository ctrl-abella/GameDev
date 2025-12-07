using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GunSwitcher : MonoBehaviour
{
    public GameObject ak47;
    public GameObject pistol;

    private GameObject currentWeapon;

    // ⭐ This will be read by the UI
    public static WeaponType currentWeaponType;

    void Start()
    {
        Equip(ak47);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            Equip(ak47);

        if (Input.GetKeyDown(KeyCode.Alpha2))
            Equip(pistol);
    }

    void Equip(GameObject weapon)
    {
        if (currentWeapon == weapon) return;

        ak47.SetActive(false);
        pistol.SetActive(false);

        weapon.SetActive(true);
        currentWeapon = weapon;

        // ⭐ Set weapon type for UI
        if (weapon == ak47)
            currentWeaponType = WeaponType.Rifle;
        else if (weapon == pistol)
            currentWeaponType = WeaponType.Pistol;
    }

    public GameObject GetCurrentWeapon()
    {
        return currentWeapon;
    }
}
public enum WeaponType { Rifle, Pistol }
