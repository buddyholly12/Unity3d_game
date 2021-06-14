using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSetupScript : MonoBehaviour
{
    public Camera spectateCam;
    public Camera playerCam;
    // Start is called before the first frame update
    void Start()
    {
        playerCam.enabled = true;
        spectateCam.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
