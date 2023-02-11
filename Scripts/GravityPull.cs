using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityPull : MonoBehaviour
{
    Transform playerTrans;
    Rigidbody2D playerBody;
    public float influenceRange;
    public float distanceToPlayer;
    public float intensity;
    Vector2 pullForce;

    // Start is called before the first frame update
    void Start()
    {
        playerBody = playerTrans.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        distanceToPlayer = Vector2.Distance(playerTrans.position, transform.position);
        if(distanceToPlayer <= influenceRange)
        {
            pullForce = (playerTrans.position - transform.position).normalized / distanceToPlayer * intensity;
            playerBody.AddForce(pullForce, ForceMode2D.Force);
        }
    }
}
