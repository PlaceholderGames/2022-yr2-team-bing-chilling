using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;


public class EnemyFPS : MonoBehaviour
{
    private NavMeshAgent Mob;
    private GameObject Player;
    public float MobDistanceRun = 4.4f;
    public int moneyToGive = 20;

    //which am taking from Ka
    //Code from Brackeys on YouTube
    public float starthealth = 100;
    private float health;
    public Image healthBar;

    private bool canTakeDamage;

    GameOver gameOver;
    private void Awake()
    {
        gameOver = GameObject.Find("ManagingScripts").GetComponent<GameOver>();
        Player = GameObject.Find("BetterPlayer");
    }
    private void Start()
    {
        health = starthealth;
        Mob = GetComponent<NavMeshAgent>();
    }
    void Update()
    {
        float distance = Vector3.Distance(transform.position, Player.transform.position);

        //if(distance < MobDistanceRun)
        //{
            Vector3 dirToPlayer = transform.position - Player.transform.position;
            Vector3 newPos = transform.position - dirToPlayer;
            Mob.SetDestination(newPos);
        //}

        //Mob.SetDestination(Player.transform.position);




    }

    //Reference, Code Idea from Brackeys on YouTube
    public void TakeDamage(float amount)
    {
        health -= amount;
        healthBar.fillAmount = health / starthealth;

        if (health <= 0)
        {

            Die();
            SoundManagerScript.PlaySound("deathSmallEnemy");
            PlayerStats.Money = PlayerStats.Money + moneyToGive;
            Debug.Log(PlayerStats.Money);
        }
    }

    //Reference, Code Idea from Brackeys on YouTube
    void Die()
    {
        WaveSpawner.EnemiesAlive--;
        Destroy(gameObject);
    }

   //private void OnCollisionEnter(Collision collision)
   //{
   //    if (collision.gameObject.tag == "Player")
   //    {
   //        //yes magic number
   //        Debug.Log("BING CHILLING you are dead");
   //        collision.gameObject.GetComponent<PlayerMovement>().TakeDamage(2);
   //
   //
   //    }
   //}

    //private void OnCollisionStay(Collision collision)
    //{
    //    if (collision.gameObject.tag == "Player")
    //    {
    //        if(canTakeDamage == true)
    //        {
    //        StartCoroutine(WaitForSeconds());
    //        collision.gameObject.GetComponent<PlayerMovement>().TakeDamage(2);
    //        //yes magic number
    //
    //        }
    //
    //
    //    }
    //}
    // called each frame the collider is colliding
    float _timeColliding;
    // Time before damage is taken, 1 second default
    public float timeThreshold = 1f;

    // player health I assume?
    int _currentHealth = 100;

    // called when first colliding
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // Reset timer
            _timeColliding = 0f;

            Debug.Log("Enemy started colliding with player.");

            // Take damage on impact?
            collision.gameObject.GetComponent<PlayerMovement>().TakeDamage(2);
        }
    }

    // called each frame the collider is colliding
    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // If the time is below the threshold, add the delta time
            if (_timeColliding < timeThreshold)
            {
                _timeColliding += Time.deltaTime;
            }
            else
            {
                // Time is over theshold, player takes damage
                collision.gameObject.GetComponent<PlayerMovement>().TakeDamage(2);
                // Reset timer
                _timeColliding = 0f;
            }
        }
    }

    //-----------------------------------------
    void PlayerDamage(int amount)
    {
        _currentHealth -= amount;
        Debug.Log(_currentHealth);
        if (_currentHealth <= 0f)
        {
            Die();
        }
    }
}




