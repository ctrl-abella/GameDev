using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public int currentMagAmmo;
    public int magSize = 15;

    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireForce = 500f;
    public Camera playerCam;

    void Awake()
    {
        currentMagAmmo = magSize; // start with full mag
    }
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && currentMagAmmo > 0)
        {
            Shoot();
            currentMagAmmo--;
        }

        if (Input.GetKeyDown(KeyCode.R))
            Reload();
    }

    void Reload()
    {
        int needed = magSize - currentMagAmmo;
        int supply = AmmoManager.Instance.pistolAmmo;

        int used = Mathf.Min(needed, supply);

        AmmoManager.Instance.pistolAmmo -= used;
        currentMagAmmo += used;
    }

    void Shoot()
    {
        Ray ray = playerCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        Vector3 targetPoint;

        if (Physics.Raycast(ray, out hit))
            targetPoint = hit.point;
        else
            targetPoint = ray.GetPoint(100f);

        Vector3 direction = (targetPoint - firePoint.position).normalized;

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.LookRotation(direction));
        bullet.GetComponent<Rigidbody>().AddForce(direction * fireForce, ForceMode.Impulse);
    }
}


