using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private EnemyData ed;

    private float currentHealth;

    protected virtual void Start()
    {
        currentHealth = ed.maxHealth;
    }

    protected virtual void Update()
    {

    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
    }

    public Animator GetAnim()
    {
        return anim;
    }
}
