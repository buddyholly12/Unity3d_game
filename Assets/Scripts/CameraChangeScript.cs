using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChangeScript : MonoBehaviour
{
    public Camera spectatorCam;
    public Camera activePlayerCam;
    public SpawnerScript spawnScript;
    // Start is called before the first frame update
    void Start(){
        activePlayerCam = spawnScript.GetSpawnTrackerCam();
    }

    // Update is called once per frame
    void Update(){


        if (activePlayerCam == null) {
            ChangeToSpectatorCam();
        }
        else
        {
            ChangeToPlayerCam();
        }
    }

    void ChangeToPlayerCam() {
        activePlayerCam.enabled = true;
        spectatorCam.enabled = false;
    }

    void ChangeToSpectatorCam(){
        spectatorCam.enabled = true;
        activePlayerCam.enabled = false;
    }

}
