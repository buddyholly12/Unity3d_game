using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawnerScript : MonoBehaviour
{
    public Vector3 center, size;
    public GameObject[] spawnees;
    public List<GameObject> spawneeTracker;
    public bool stopSpawning = false;
    public float spawnTime;
    public float spawnDelay;
    public int stop;
    // Start is called before the first frame update
    void Start()
    {
        stop = 0;
        InvokeRepeating("SpawnObject", spawnTime, spawnDelay);
    }

    // Update is called once per frame
    void Update()
    {
        spawneeTracker.ForEach(delegate(GameObject gamObj){
            if (gamObj == null) {
                spawneeTracker.Remove(gamObj);
            }
        });

        if (stop == 1 && stopSpawning == false)
        {
            InvokeRepeating("SpawnObject", spawnTime, spawnDelay);
            stop = 0;
        }
    }
    public void SpawnObject()
    {
        Vector3 pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2),
            Random.Range(-size.y / 2, size.y / 2),
            Random.Range(-size.z / 2, size.z / 2));

        int randomInt = Random.Range(0, spawnees.Length);
        spawneeTracker.Add(Instantiate(spawnees[randomInt], pos, Quaternion.identity));

        if (stopSpawning)
        {
            CancelInvoke("SpawnObject");
            stop = 1;
        }


    }

    public bool SpawnedInstanceDestroyed() {
        Debug.Log("1 Kill");
        return true;
    }
}
