using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinLoseConditionScript : MonoBehaviour
{
    public RandomSpawnerScript RandSpawnScr;
    public int zombieToKill = 1;
    public int livesLeft = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (RandSpawnScr.SpawnedInstanceDestroyed())
        //{
        //    zombieToKill--;
        //}
        if (zombieToKill < 1)
        {
            Time.timeScale = 0;
            Debug.Log("Win");
        }
        else if (livesLeft < 1) {
            Time.timeScale = 0;
            Debug.Log("Lose");
        }
    }
}
