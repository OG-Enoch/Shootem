using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{
    public float speed;
    public float lifeTime;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifeTime);
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.GetComponent<Enemy>().TakeDamage();
        DestroyProjectile();
    }

    void DestroyProjectile()
    {
        Destroy(gameObject);
    }

    private void FixedUpdate()
    {
       //rb.AddForce(Vector2.up * speed * Time.deltaTime, ForceMode2D.Impulse);
    }
}
