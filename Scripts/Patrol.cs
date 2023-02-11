using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    private float speed;

    private float waitTime;

    private float startWaitTime;

    private Transform moveSpots;

    private int randomSpot;

    public float minX = -26.5f, maxX = 26.5f, minY = -61.4f, maxY = 61.3f;

    // Start is called before the first frame update
    void Start()
    {
        startWaitTime = Random.Range(1, 6);
        speed = Random.Range(5, 20);
        waitTime = startWaitTime;
        moveSpots = GameObject.FindGameObjectWithTag("MoveSpot").transform;
        moveSpots.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, moveSpots.position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, moveSpots.position) < 0.2f)
        {
            moveSpots.position =
                new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
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
