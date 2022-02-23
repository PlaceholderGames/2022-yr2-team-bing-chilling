using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManagement : MonoBehaviour
{
    // To be used on the "PLAY" button to move from the menu to a level.
    // To use on the finish of the level to load the next one.
    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Debug.Log("EXIT GAME");
        Application.Quit();
    }
}