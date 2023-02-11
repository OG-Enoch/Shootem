using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health;
    public float damageAmount;
    public GameObject particle;
    private GameObject player;
    public GameObject scoreParticle;
    public GameObject hitParticle;
    public int score;
    [HideInInspector]public bool isDead = false;
    //public Animator camShake;
  
    // Start is called before the first frame update
    public virtual void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");      
    }

    // Update is called once per frame
    public virtual void Update()
    {
        if(player == null)
        {
            Destroy(gameObject);
            Instantiate(particle, transform.position, Quaternion.identity);
        }
    }
    public void TakeDamage()
    {
        health -= damageAmount;
        Instantiate(hitParticle, transform.position, Quaternion.identity);
        if (health <= 0)
        {
            DestroyEnemy();
            ScoreManager.score += score;
        }
    }
    void DestroyEnemy()
    {
        //camShake.SetTrigger("Shake");
        Destroy(gameObject);
        Instantiate(particle, transform.position, Quaternion.identity);
        Instantiate(scoreParticle, transform.position, Quaternion.identity);
    }

    void OnColliderEnter2D(Collider2D collision)
    {
        if(collision.tag  == "Destroyer")
        {
            Destroy(gameObject);
            DestroyEnemy();
        }
    }

}
