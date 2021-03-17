using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;
    public float gravity = -9.8f;
    public float jumpHeight = 4f;
    
    Vector3 velocity;
    bool isGrounded;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0) {
            velocity.y = -2f;
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        Vector3 moveAlg = move * speed * Time.deltaTime;
        // find a way to blend movement from idle to run
        anim.SetFloat("MoveSpeed",z);
        controller.Move(moveAlg);


        if (Input.GetButtonDown("Jump") && isGrounded == true) {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
