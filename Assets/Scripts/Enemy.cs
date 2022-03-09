using UnityEngine.UI;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int moneyToGive = 0;
    public float speed = 8f;

    //Code from Brackeys on YouTube
    public float starthealth = 100;
    private float health;
    public Image healthBar;



    void Start()
    {
        health = starthealth;
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
