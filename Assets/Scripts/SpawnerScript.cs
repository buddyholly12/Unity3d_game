using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public GameObject toSpawn;
    public GameObject SpawnTracker;
    public WinLoseConditionScript WLCS;
    public int currentSpawned = 0;
    public int maxSpawnable;

    // Start is called before the first frame update
    void Start()
    {
        maxSpawnable = WLCS.getPlayerSpawnLimit();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && SpawnTracker == null) {
            SpawnAndTrack(toSpawn);
        }

        if (currentSpawned >= maxSpawnable && SpawnTracker == null) {
            WLCS.Lose();
        }
    }

    void SpawnAndTrack(GameObject prefabrication) {
        SpawnTracker = Instantiate(prefabrication, transform);
        currentSpawned++;
    }
    public Camera GetSpawnTrackerCam() {
        return SpawnTracker.GetComponentInChildren<Camera>();
    }


}
