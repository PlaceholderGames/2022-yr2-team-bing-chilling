using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
    public int lives = 3;

    GameOver gameOver;
    private void Awake()
    {
        gameOver = GameObject.Find("ManagingScripts").GetComponent<GameOver>();
    }


    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Debug.Log("BING CHILLING ");
            lives--;
            if(lives <= 0)
            {
                gameOver.YouHaveDied();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
