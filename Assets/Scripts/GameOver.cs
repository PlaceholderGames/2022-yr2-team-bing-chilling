using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public int BaseLives = 3;
    public GameObject deathPanel;
    public Text livesDisplay;
    // Start is called before the first frame update
    void Start()
    {
        livesDisplay.text = BaseLives.ToString();

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

    public void ReturnToMain()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }    
    public void Retry()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void theyBreachedBase()
    {
        BaseLives--;
        livesDisplay.text = BaseLives.ToString();
        if (BaseLives <= 0)
        {
            YouHaveDied();
        }
    }
}
