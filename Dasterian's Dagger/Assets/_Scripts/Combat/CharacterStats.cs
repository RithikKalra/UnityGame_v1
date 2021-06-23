using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public int health;
    public int damage;
    public Player player;
    public Transform coin;

    //public HealthBarController healthBar;

    void Start()
    {
        //healthBar.SetMaxHealth(health);
    }

    public void TakeDamage(int damageTaken)
    {
        health -= damageTaken;
        //healthBar.SetHealth(health);

        if (health <= 0)
        {
            Invoke("Die", 0.6f);
        }
    }

    public void Die()
    {
        if (this.gameObject.CompareTag("EnemyTroll"))
        {
            Vector2 pos = transform.position;
            pos = new Vector2(transform.position.x + 1, transform.position.y + 1);
            Instantiate(coin, pos, Quaternion.identity);
        }

        Destroy(this.gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Attack"))
        {
            TakeDamage(player.attackDamage);
        }
    }
}