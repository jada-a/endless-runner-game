using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 2;
    private int currentHealth;
    public float speed;
    public float stoppingDistance;
    public float retreatDistance;

    private float timeBetweenShots;
    public float startTimeBetweenShots;

    public GameObject projectile;

    public ScoreManager scoreManager;

    public Transform player;

    public Animator anim;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        timeBetweenShots = startTimeBetweenShots;
        currentHealth = maxHealth;
        scoreManager = FindObjectOfType<ScoreManager>();


    }

    // Update is called once per frame
    void Update()
    {
        if (timeBetweenShots <= 0 && Vector2.Distance(transform.position, player.position) < stoppingDistance)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            timeBetweenShots = startTimeBetweenShots;
            anim.SetTrigger("Attack");
        }
        else 
        {
            timeBetweenShots -= Time.deltaTime;
        }
    }

    public void TakeDamage(int damage) 
    {
        currentHealth -= damage;
        anim.SetTrigger("Hit");
        if (currentHealth <= 0) 
        {
            Die();
        }

    }

    void Die()
    {
        Debug.Log("Enemy died!");
        scoreManager.AddScore(100);
        anim.SetBool("isDead", true);
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }
}
