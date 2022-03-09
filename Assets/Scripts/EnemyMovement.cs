using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{

    private Transform target;
    private int wavepointIndex = 0;
    GameOver gameOver;
    private Enemy enemy;

    private void Awake()
    {
        enemy = GetComponent <Enemy>();
        gameOver = GameObject.Find("ManagingScripts").GetComponent<GameOver>();
    }

    void Start()
    {
        target = WaypointsFollow.points[0];
    }
    private void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * enemy.speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWaypoint();
        }
    }

    void GetNextWaypoint()
    {
        if (wavepointIndex >= WaypointsFollow.points.Length - 1)
        {
            Destroy(gameObject);
            gameOver.theyBreachedBase();
            return;
        }

        wavepointIndex++;
        target = WaypointsFollow.points[wavepointIndex];
    }


}
