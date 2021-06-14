using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public GameObject toSpawn;
    public GameObject SpawnTracker;
    // Start is called before the first frame update
    void Start()
    {
        //Spawn(toSpawn);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && SpawnTracker == null) {
            SpawnAndTrack(toSpawn);
        }
    }

    void SpawnAndTrack(GameObject prefabrication) {
        SpawnTracker = Instantiate(prefabrication, transform);
    }

    public Camera GetSpawnTrackerCam() {
        //return SpawnTracker.GetComponentInChildren(typeof(Camera)) as Camera;
    }


}
