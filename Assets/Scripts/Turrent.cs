using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turrent : MonoBehaviour
{
    //change this to private
    private Transform target;

    [Header("Things to mess with")]
    public float rangeOfTurrent = 15f;
    public float fireRate = 1f;
    private float fireCountdown = 0f;
    public float turnSpeed = 10f;

    public bool useLaser = false;
    public LineRenderer lineRenderer;
    public int damageOverTime = 30;
    [Header("Don't touch this")]
    //REMEMBER TO ADD A SECOND TAG ON ENEMIES
    //also don't change shit here dan
    public string enemyTag = "Enemy";
    public Transform partToRotate;
    public GameObject turrentBulletPrefab;
    public Transform firePoint;

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
        {
            if (useLaser)
            {
                if (lineRenderer.enabled)
                    lineRenderer.enabled = false;
            }

            return;
        }

        LockOnTarget();

        if (useLaser)
        {
            Laser();
        }
        else
        {
            if (fireCountdown <= 0f)
            {
                TurrentShoot();
                fireCountdown = 1f / fireRate;
            }
            fireCountdown -= Time.deltaTime;
        }



    }

    void LockOnTarget()
    {
        Vector3 direction = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }


    void Laser()
    {

        target.GetComponent<Enemy>().TakeDamage(damageOverTime * Time.deltaTime);
        if (!lineRenderer.enabled)
            lineRenderer.enabled = true;

        lineRenderer.SetPosition(0, firePoint.position);
        lineRenderer.SetPosition(1, target.position);
    }

    void TurrentShoot()
    {
        //Debug.Log("CRINGEEEE");
        GameObject bulletGo = (GameObject)Instantiate(turrentBulletPrefab, firePoint.position, firePoint.rotation);
        TurrentBullet bullet = bulletGo.GetComponent<TurrentBullet>();

        if(bullet != null)
        {
            bullet.Seek(target);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, rangeOfTurrent);
    }

    

}
