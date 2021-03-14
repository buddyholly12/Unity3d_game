using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPSCam : MonoBehaviour
{
    public Transform follow;
    public float XOffset = 0;
    public float YOffset = 0;
    public float ZOffset = 0;
    public float mouseSensitivity = 100;
    Vector3 newPos;
    Quaternion newRot;

    float xRotation = 0f;
    //Quaternion newRot;

    // Start is called before the first frame update
    void Start()
    {
        
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        follow.Rotate(Vector3.up * mouseX);
        

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRotation,0f,0f);

        newPos = new Vector3(follow.transform.position.x + XOffset, follow.transform.position.y + YOffset, follow.transform.position.z + ZOffset);
        transform.position = newPos;
    }
}
