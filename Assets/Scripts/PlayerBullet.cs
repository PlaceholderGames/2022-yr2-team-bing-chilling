using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    //making an instance if we want to for example upgrade the damage on bullet
    //public static PlayerBullet instance;

    //damage that the bullet will do
    public float damageToDoForBlue;
    public float damageToDoForRed;


    public bool thisIsARedBullet;
    public bool thisIsABlueBullet;

    //later change it to blue boys and red boys
    //but why?
    //coz upgrades you retard
    public float damageToBigBoys = 5;

    private Transform target;
    Enemy enemy;

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        //this is meant for small red enemy
        if (collision.gameObject.tag == "EnemyRed" && thisIsABlueBullet == true)
        {
            Debug.Log("BING CHILLING red is dead");
            collision.gameObject.GetComponent<EnemyFPS>().TakeDamage(damageToDoForRed);

        }
        //this is meant for small blue enemy
        if (collision.gameObject.tag == "EnemyBlue" && thisIsARedBullet == true)
        {
            Debug.Log("BING CHILLING blue is dead");
            collision.gameObject.GetComponent<EnemyFPS>().TakeDamage(damageToDoForBlue);
        }

        //this is meant for large red enemy
        if (collision.gameObject.tag == "Enemy" && collision.gameObject.GetComponent<Red>() != null && thisIsABlueBullet == true)
        {
            collision.gameObject.GetComponent<Enemy>().TakeDamage(damageToBigBoys);
            Debug.Log("BING CHILLING");
        }

        //this is meant for large blue enemy
        if (collision.gameObject.tag == "Enemy" && collision.gameObject.GetComponent<Blue>() != null && thisIsARedBullet == true)
        {
            collision.gameObject.GetComponent<Enemy>().TakeDamage(damageToBigBoys);
            Debug.Log("BING CHILLING");
        }
        //destroy it's self on contact with other object
        Destroy(gameObject);
    }


}
