using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragFingerMove : MonoBehaviour
{
    private Vector3 touchPosition;
    private Rigidbody2D rb;
    private Vector3 direction;
    private float moveSpeed = 10f;
    public float minX, maxX, minY, maxY;
    GhostController ghostController;
    Animator anim;
    float movement;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ghostController = GetComponent<GhostController>();
        ghostController.enabled = false;
        anim = GetComponent<Animator>();
        anim.SetTrigger("Spawn");
    }

    // Update is called once per frame
    void Update()
    {
        movement = Input.GetAxisRaw("Horizontal");
        

        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Moved)
            {
                touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
                touchPosition.z = 0;
                transform.position = new Vector2(Mathf.Clamp(transform.position.x, minX, maxX), Mathf.Clamp(transform.position.y, minY, maxY));
                direction = (touchPosition - transform.position);
                rb.velocity = new Vector2(direction.x, direction.y) * moveSpeed;
                ghostController.enabled = true;
            }
            

            if(touch.phase == TouchPhase.Ended)
            {
                rb.velocity = Vector2.zero;
                ghostController.enabled = false;
            }
        }
    }
    void FixedUpdate()
    {
        transform.position = new Vector2(transform.position.x + movement * 30f * Time.deltaTime, transform.position.y);
    }
}
