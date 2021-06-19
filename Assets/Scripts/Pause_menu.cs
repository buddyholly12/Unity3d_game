using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Pause_menu : MonoBehaviour
{
    // Start is called before the first frame update
    public string MainMenuScene;
    public GameObject pauseMenu;
    public bool isPaused;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
        	isPaused = false;
        	pauseMenu.SetActive(false);
        	Time.timeScale = 0f;
        }
        else
        {
        	isPaused = true;
        	pauseMenu.SetActive(true);
        }
    }
    public void Resume()
    {
    		isPaused = false;
        	pauseMenu.SetActive(false);
        	Time.timeScale = 0f;
    }
    public void ReturntoMain()
    {
     SceneManager.LoadScene("MainMenu");
    } 
    
}
