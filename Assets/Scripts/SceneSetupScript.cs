using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSetupScript : MonoBehaviour
{
    public Camera spectateCam;
    public Camera playerCamera;
    // Start is called before the first frame update
    void Start()
    {
        spectateCam.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
