using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turrent : MonoBehaviour
{
    //change this to private
    public Transform target;
    public float rangeOfTurrent = 15f;

    public Transform partToRotate;

    public float turnSpeed = 10f;
//
//    //how many shoots per sec
//    public float fireRate = 1f;
//    private float fireCountdown = 0f;
//
//
//    //REMEMBER TO ADD A SECOND TAG ON ENEMIES
    public string enemyTag = "Enemy";

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position );
            if(distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= rangeOfTurrent)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }


    }


    // Update is called once per frame
    void Update()
    {
        if( target == null)
            return;

        Vector3 direction = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        //Vector3 rotation = lookRotation.eulerAngles;
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
//
//        //if(fireCountdown <= 0f)
//        //{
//        //    TurrentShoot();
//        //    fireCountdown = 1f / fireRate;
//        //}
//        //fireCountdown -= Time.deltaTime;
//
    }
//
//    void TurrentShoot()
//    {
//        Debug.Log("CRINGEEEE");
//    }
//
//
//
//
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, rangeOfTurrent);
    }


}
