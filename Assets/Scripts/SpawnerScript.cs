using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public GameObject toSpawn;
    // Start is called before the first frame update
    void Start()
    {
        Spawn(toSpawn);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawn(GameObject prefabrication) {
        Instantiate(prefabrication, transform);
    }


}
