using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    public GameObject PauseCanvas;
    public bool gameIsPaused = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (gameIsPaused == false) {
                Pause();
            }
            else
            {
                Resume();
            }
        }
    }

    public void Pause() {
        gameIsPaused = true;
        Time.timeScale = 0f;
        PauseCanvas.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
    }

    public void Resume() {
        gameIsPaused = false;
        Time.timeScale = 1f;
        PauseCanvas.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void ReturnToMenu() {
        SceneManager.LoadScene("MainMenu");
    }
}
