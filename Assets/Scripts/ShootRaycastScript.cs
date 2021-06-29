using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootRaycastScript : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public Camera ShootersCam;
    public int ammoCount = 10;
    public int ammoMax = 10;
    public AmmoUIScript AmmoScript;
    private bool isReloading = false;
    private float reloadTime = 1;
    private float reloadTimer = 0;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && !Input.GetButton("Fire2") && ammoCount > 0) {
            Shoot();
        }
        if (Input.GetKeyDown(KeyCode.R)) {
            Reload();
        }
        if (isReloading == true) {
            Reloading();
        }
        AmmoScript.refreshAmmoDisplay(ammoCount,ammoMax);
    }

    void Shoot() {
        RaycastHit hit;
        if (Physics.Raycast(ShootersCam.transform.position, ShootersCam.transform.forward, out hit, range)) {
            Debug.Log(hit.transform.name);
            TakeDamageScript tds = hit.transform.GetComponent<TakeDamageScript>();

            if (tds != null) {
                tds.TakeDamage(damage);
            }
        }
        ammoCount -= 1;
        
    }

    void Reload() {
        isReloading = true;   
    }

    void Reloading()
    {
        reloadTimer += Time.deltaTime;
        if (reloadTimer >= reloadTime)
        {
            SetReadyAmmo(ammoMax);
            reloadTimer = 0;
            isReloading = false;
        }
    }
    void SetMaxAmmo(int maximumAmmo) {
        ammoMax = maximumAmmo;
    }

    void SetReadyAmmo(int readyAmmo) {
        ammoCount = readyAmmo;
    }
}
