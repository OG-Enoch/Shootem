using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pusher : Enemy
{
    private Animator anim;
    private float speed;

    private float waitTime;

    public float startWaitTime;

    private Transform moveSpots;

    private int randomSpot;

    public float minX = -26.5f, maxX = 26.5f, minY = -61.4f, maxY = 61.3f;
    
    public override void Start()
    { 
        base.Start();
        anim =  GetComponent<Animator>();
        startWaitTime =  Random.Range(4, 20);
        speed = Random.Range(5, 20);
        waitTime = startWaitTime;
        moveSpots = GameObject.FindGameObjectWithTag("MoveSpot").transform;
        moveSpots.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
    }

    public override void Update()
    {
        base.Update();
       transform.position = Vector2.MoveTowards(transform.position, moveSpots.position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, moveSpots.position) < 0.2f)
        {
            //moveSpots.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
            if(waitTime <= 0)
            {
                moveSpots.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
                waitTime = startWaitTime;
            }
            else
            {
                Push();  
            }
        }
    }

    private void Push()
    {
        anim.SetTrigger("Push");
        waitTime -= Time.deltaTime;
    }

}
