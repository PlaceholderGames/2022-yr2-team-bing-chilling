using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject deathPanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void YouHaveDied()
    {
        Time.timeScale = 0f; 
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        deathPanel.SetActive(true);
    }

    void ReturnToMain()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MenuScene");
    }
}
