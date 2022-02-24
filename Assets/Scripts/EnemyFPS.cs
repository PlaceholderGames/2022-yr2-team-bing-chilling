using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFPS : MonoBehaviour
{
    private NavMeshAgent Mob;
    public GameObject Player;
    public float MobDistanceRun = 4.4f;

    private void Start()
    {
        Mob = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        //float distance = Vector3.Distance(transform.position, Player.transform.position);


        Vector3 dirToPlayer = transform.position - Player.transform.position;
        Vector3 newPos = transform.position - dirToPlayer;

        Mob.SetDestination(newPos);



    }

}


