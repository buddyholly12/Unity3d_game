using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootProjectileScriptFunny : MonoBehaviour
{
    public Transform shootPoint;
    public Rigidbody projectile;
    public float projectileSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody BulletInstance;
        if (Input.GetButton("Fire1")) {
            BulletInstance = Instantiate(projectile,shootPoint.position,shootPoint.rotation) as Rigidbody;
            BulletInstance.AddForce(shootPoint.forward * projectileSpeed);
        }
    }
}
