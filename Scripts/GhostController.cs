using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostController : MonoBehaviour
{
    public GameObject ghostPrefab;
    public float delay = 1.0f;
    public Color color;
    float delta = 0;

    PlayerController player;
    SpriteRenderer spriteRenderer;
    public float destroyTime = 0.1f;
    public Material material = null;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(delta > 0)
        {
            delta -= Time.deltaTime;
        }
        else
        {
            delta = delay;
            CreateGhost();
        }
    }
    
    void CreateGhost()
    {
        GameObject ghostObj = Instantiate(ghostPrefab, transform.position, transform.rotation);
        ghostObj.transform.localScale = player.transform.localScale;
        Destroy(ghostObj, destroyTime);

        spriteRenderer = ghostObj.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = player.spriteRenderer.sprite;
        spriteRenderer.color = color;
        if(material != null)
        {
            spriteRenderer.material = material;
        }
    }
}
