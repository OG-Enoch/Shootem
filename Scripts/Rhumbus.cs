using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rhumbus : Enemy
{
    public float rotationSpeed;
    SpriteRenderer sp;
    float colorPanel1, colorPanel2, colorPanel3;
    private GameObject player;
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        player = GameObject.FindGameObjectWithTag("Player").gameObject;
        //Gets Random Colors
        colorPanel1 = Random.Range(0f, 1f);
        colorPanel2 = Random.Range(0f, 1f);
        colorPanel3 = Random.Range(0f, 1f);
        sp = GetComponent<SpriteRenderer>();
        //sp.color = new Color(colorPanel1, colorPanel2, colorPanel3, 1f);

    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        //transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }
    /*void Fall()
    {
        if (player != null)
        {
            transform.Translate(Vector2.down * speed * Time.deltaTime);
        }
    }*/
}
