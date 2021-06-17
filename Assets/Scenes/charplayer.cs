using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charplayer : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator Anim;
    public float movex;
    public float movey;
    public Rigidbody test;
    public Rigidbody test2;
    public Transform target;
    public float movespeed;
    void Start()
    {
        Anim = GetComponent<Animator>();
        movespeed =1f;
    }

    // Update is called once per frame
    void Update()
    {
    float moveH = Input.GetAxis("Horizontal");
        float moveV = Input.GetAxis("Vertical");
    
     if(Input.GetKey(KeyCode.UpArrow))
        {
        	Vector3 PosisiPlayer = transform.position;
        	PosisiPlayer.z += 0.01f;
        	transform.position = PosisiPlayer;
        	    movex = Input.GetAxis("Horizontal");
        Anim.SetFloat("movex",movex);
        movey = Input.GetAxis("Vertical");
        Anim.SetFloat("movey",movey);	
         transform.Translate(movespeed*moveH*Time.deltaTime,0f,movespeed*moveV*Time.deltaTime);
        }
        else if(Input.GetKey(KeyCode.DownArrow))
        {
        Vector3 PosisiPlayer = transform.position;
        	PosisiPlayer.z -= 0.01f;
        	transform.position = PosisiPlayer;
        	    movex = Input.GetAxis("Horizontal");
        Anim.SetFloat("movex",movex);
        movey = Input.GetAxis("Vertical");
        Anim.SetFloat("movey",movey);	
        transform.Translate(movespeed*moveH*Time.deltaTime,0f,movespeed*moveV*Time.deltaTime);
        }
        Rigidbody BulletInstance;
        	if (Input.GetButtonDown("Fire1"))
        	{
        		BulletInstance	= Instantiate(test,target.position,target.rotation) as Rigidbody;
        		BulletInstance.AddForce(target.forward * 2000);
        	}
        	else if(Input.GetButtonDown("Fire2"))
        	{
        		BulletInstance	= Instantiate(test2,target.position,target.rotation) as Rigidbody;
        		BulletInstance.AddForce(target.forward * 1300);
        	}
    
    }
}
