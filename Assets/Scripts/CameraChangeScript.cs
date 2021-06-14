using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChangeScript : MonoBehaviour
{
    public Camera spectatorCam;
    public Camera playerCam;
    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        if (playerCam == null) {
            ChangeToSpectatorCam();
        }
        else
        {
            ChangeToPlayerCam();
        }
    }

    void ChangeToPlayerCam() {
        playerCam.enabled = true;
        spectatorCam.enabled = false;
    }

    void ChangeToSpectatorCam(){
        spectatorCam.enabled = true;
        playerCam.enabled = false;
    }

}
