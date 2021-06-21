using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChangeScript : MonoBehaviour
{
    public Camera spectatorCam;
    private Camera activePlayerCam;
    public SpawnerScript spawnScript;
    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        try
        {
            activePlayerCam = spawnScript.GetSpawnTrackerCam();
        }
        catch {
            ChangeToSpectatorCam();
        } 

        if (activePlayerCam != null) {
            ChangeToPlayerCam();
        }
        
    }

    void ChangeToPlayerCam() {
        
        activePlayerCam.enabled = true;
        spectatorCam.enabled = false;
    }

    void ChangeToSpectatorCam(){
        //activePlayerCam.enabled = false;
        spectatorCam.enabled = true;
    }

}
