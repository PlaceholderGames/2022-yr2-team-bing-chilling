using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused = false;

    public GameObject pauseMenuUI;
    CameraController cameraController;

    private void Awake()
    {
        cameraController = GameObject.Find("ManagingScripts").GetComponent<CameraController>();
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)){
            if (isPaused){
                Resume();
            }
            else{
                Pause();
            }
        }   
    }

    public void Resume()
    {
        if (cameraController.cringe == 2)
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void ReturnMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MenuScene");
    }

    void Pause()
    {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;



            pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;

    }
}
