using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private float speed;
    private GameObject destroyer;
    
    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(5f, 20f);
        destroyer = GameObject.FindGameObjectWithTag("Destroyer");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, destroyer.transform.position, speed * Time.deltaTime);
    }
}
