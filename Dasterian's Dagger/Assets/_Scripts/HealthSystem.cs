using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public Animator[] hAnimations;
    public int health;
    public GameObject heart;

    Stack<Animator> heartAnimator = new Stack<Animator>();
    private int maxHealth = 3;
    
    void Start()
    {
        for(int i = 0; i < hAnimations.Length; i++)
        {
            heartAnimator.Push(hAnimations[i]);
        }
    }

    public void damagePlayer(int damage)
    {
        heartAnimator.Pop().SetBool("isHurt", true);
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
    public void restoreHealth(int amount)
    {
        for(int i = 0; i < amount; i++)
        {
            //heartAnimator.Push(hAnimations[heartAnimator.Count() - 1]);
        }
    }
}
