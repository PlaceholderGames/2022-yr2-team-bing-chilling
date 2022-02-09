using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    //making an instance if we want to for example upgrade the damage on bullet
    public static PlayerBullet instance;

    //damage that the bullet will do
    public float damageToDo;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        //destroy it's self on contact with other object
        Destroy(gameObject);

    }

}
