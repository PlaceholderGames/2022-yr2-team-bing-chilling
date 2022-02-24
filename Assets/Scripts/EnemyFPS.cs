using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;


public class EnemyFPS : MonoBehaviour
{
    private NavMeshAgent Mob;
    public GameObject Player;
    public float MobDistanceRun = 4.4f;

    //which am taking from Ka
    //Code from Brackeys on YouTube
    public float starthealth = 100;
    private float health;
    public Image healthBar;

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
        }
    }

    //Reference, Code Idea from Brackeys on YouTube
    void Die()
    {
        Destroy(gameObject);
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.tag == "Player")
    //    {
    //        Debug.Log("BING CHILLING you are dead");
    //
    //    }
    //}

}


