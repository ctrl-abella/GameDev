using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rifle : MonoBehaviour
{
    public int currentMagAmmo;
    public int magSize = 30;

    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireForce = 700f;
    public float fireRate = 0.1f;
    public Camera playerCam;

    private float nextFireTime = 0f;

    void Awake()
    {
        currentMagAmmo = magSize;
    }

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextFireTime && currentMagAmmo > 0)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
            currentMagAmmo--;
        }

        if (Input.GetKeyDown(KeyCode.R))
            Reload();
    }

    void Reload()
    {
        int needed = magSize - currentMagAmmo;
        int supply = AmmoManager.Instance.rifleAmmo;

        int used = Mathf.Min(needed, supply);

        AmmoManager.Instance.rifleAmmo -= used;
        currentMagAmmo += used;
    }

    void Shoot()
    {
        // Ray from center of camera
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
