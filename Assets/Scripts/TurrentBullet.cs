using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurrentBullet : MonoBehaviour
{
    private Transform target;

    public float speed = 60f;
    public int damage = 50;

    public void Seek (Transform _target)
    {
        target = _target;
    }

    // Update is called once per frame
    void Update()
    {
        if(target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 directtion = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if(directtion.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(directtion.normalized * distanceThisFrame, Space.World);

    }

    //Reference, Took Ideas from Brackeys on YouTube
    void HitTarget()
    {
        Damage(target);
        Destroy(gameObject);
    }

    //Reference. Took ideas from Brackeys on YouTube
    void Damage(Transform enemy)
    {
        Enemy e = enemy.GetComponent<Enemy>();

        if (e != null)
        {
            e.TakeDamage(damage);
        }
    }

}
