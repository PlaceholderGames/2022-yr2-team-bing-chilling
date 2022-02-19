using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurrentBullet : MonoBehaviour
{
    private Transform target;

    public float speed = 60f;

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

    void HitTarget()
    {
        Debug.Log("Oh no he's hurt");
        Destroy(gameObject);
    }

}
