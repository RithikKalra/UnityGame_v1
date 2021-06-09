using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public Animator[] heartAnimator;
    public int health;
    

    private int maxHealth = 12;
    private int index = 0;
    

    public void damagePlayer(int damage)
    {
        heartAnimator[index].SetBool("isHurt", true);
        index++;
        health -= damage;
    }
    public int getMaxHealth()
    {
        return maxHealth;
    }
    public void setMaxHealth(int mHealth)
    {
        maxHealth = mHealth;
    }
}
