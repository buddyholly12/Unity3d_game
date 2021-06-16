using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootRaycastScript : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public Camera ShootersCam;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && !Input.GetButton("Fire2")) {
            Shoot();
        }
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
    }
}
