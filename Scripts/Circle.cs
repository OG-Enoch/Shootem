using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : Enemy
{
    private float speed;

    private float waitTime;

    private float startWaitTime;

    private Transform moveSpots;

    private int randomSpot;

    public float minX = -26.5f, minY = -61.4f, maxX = 26.5f, maxY = 61.3f;
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        speed = Random.Range(0, 20);
        startWaitTime = Random.Range(0, 3);
        waitTime = startWaitTime;
        moveSpots = GameObject.FindGameObjectWithTag("MoveSpot").transform;
        moveSpots.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
        
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        transform.position = Vector2.MoveTowards(transform.position, moveSpots.position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, moveSpots.position) < 0.2f)
        {
            moveSpots.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
            if(waitTime <= 0)
            {
                moveSpots.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }  
    }
}
