using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public Text scoreText2;
    Enemy enemy;
    [HideInInspector] public static float score;
    
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {   
        //score += Time.deltaTime;
        /*if(GetComponent<Enemy>().AddScore() == true)
        {
            score += GetComponent<Enemy>().score;
        }*/
        scoreText.text = score.ToString();
        scoreText2.text = score.ToString();
    }
}
