using UnityEngine.UI;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 8f;
    public int moneyToGive = 0;
    private Transform target;
    private int wavepointIndex = 0;

    //Code from Brackeys on YouTube
    public float starthealth = 100;
    private float health;
    public Image healthBar;

    GameOver gameOver;
    private void Awake()
    {
        gameOver = GameObject.Find("ManagingScripts").GetComponent<GameOver>();
    }

    void Start()
    {
        target = WaypointsFollow.points[0];
        health = starthealth;
    }

    private void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWaypoint();
        }
    }

    void GetNextWaypoint()
    {
        if(wavepointIndex >= WaypointsFollow.points.Length - 1)
        {
            Destroy(gameObject);
            gameOver.theyBreachedBase();
            return;
        }

        wavepointIndex++;
        target = WaypointsFollow.points[wavepointIndex];
    }

    //Reference, Code Idea from Brackeys on YouTube
    public void TakeDamage (float amount)
    {
        health -= amount;
        healthBar.fillAmount = health / starthealth;

        if (health <= 0)
        {
            Die();
            PlayerStats.Money = PlayerStats.Money + moneyToGive;
            //Debug.Log(PlayerStats.Money);
        }
    }
    
    //Reference, Code Idea from Brackeys on YouTube
    void Die()
    {
        Destroy(gameObject);
    }


}
