using UnityEngine.UI;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int moneyToGive = 0;
    public float startSpeed = 8f;

    [HideInInspector]
    public float speed;

    //Code from Brackeys on YouTube
    public float starthealth = 100;
    private float health;
    public Image healthBar;



    void Start()
    {
        health = starthealth;
        speed = startSpeed;
    }


    //Reference, Code Idea from Brackeys on YouTube
    public void TakeDamage (float amount)
    {
        health -= amount;
        healthBar.fillAmount = health / starthealth;

        if (health <= 0)
        {
            Die();
            SoundManagerScript.PlaySound("deathBigEnemy");
            PlayerStats.Money = PlayerStats.Money + moneyToGive;
            //Debug.Log(PlayerStats.Money);
        }
    }
    
    public void Slow(float pct)
    {
        speed = speed * (1f - pct);
    }

    //Reference, Code Idea from Brackeys on YouTube
    void Die()
    {
        WaveSpawner.EnemiesAlive--;
        Destroy(gameObject);
    }


}
