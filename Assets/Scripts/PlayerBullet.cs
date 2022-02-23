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

    public float damageToBigBoys = 20;
    public float damage;
    private Transform target;
    Enemy enemy;

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "EnemyRed" && thisIsABlueBullet == true)
        {
            Debug.Log("BING CHILLING red is dead");

        }

        if (collision.gameObject.tag == "EnemyBlue" && thisIsARedBullet == true)
        {
            Debug.Log("BING CHILLING blue is dead");

        }

        if(collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Enemy>().TakeDamage(damageToBigBoys);
            Debug.Log("BING CHILLING");
        }
        //destroy it's self on contact with other object
        Destroy(gameObject);
    }


}
