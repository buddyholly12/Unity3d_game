using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinLoseConditionScript : MonoBehaviour
{
    public RandomSpawnerScript RandSpawnScr;
    public int zombieToKill = 5;
    public int lifeLimit = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public int getSpawnLimit() {
        return zombieToKill;
    }
    // Update is called once per frame
    void Update()
    {
       
    }

    public void Win() {
        Time.timeScale = 0;
        Debug.Log("Win");
    }

    public void Lose() {
        Time.timeScale = 0;
        Debug.Log("Lose");
    }
    
}
