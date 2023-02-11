using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Animator pauseAnim;
    public GameObject panel;
    public GameObject pauseButton;
    public GameObject homeButton; 
    public Animator restartButtonAnim2;
    public Animator homeButtonAnim2;
    public Animator restartButtonAnim;
    GameObject Player;

    public Animator homeButtonAnim;
    public Animator scoreTextAnim, scoreAnim;
    public GameObject gameOverPanel;
    public GameObject score;
    public GameObject pauseSound;
    public GameObject playSound;
    public AudioSource mainSound;

    public void Pause()
    {
        StartCoroutine(Pause_W());
    }
    public void Play()
    {
        StartCoroutine(Play_W());
    }
    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GoToScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Home");
    }

    IEnumerator Pause_W()
    {
        Instantiate(pauseSound, transform.position, Quaternion.identity);
        mainSound.volume = 0.1f;
        pauseAnim.SetTrigger("ScaleUp");
        restartButtonAnim.SetTrigger("ScaleUp");
        homeButtonAnim.SetTrigger("ScaleUp");
        panel.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        pauseButton.SetActive(false);
        Time.timeScale = 0;  
    }

    IEnumerator Play_W()
    {
        Time.timeScale = 1;
        Instantiate(playSound, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.1f);
        pauseAnim.SetTrigger("ScaleDown");
        restartButtonAnim.SetTrigger("ScaleDown");
        homeButtonAnim.SetTrigger("ScaleDown");
        panel.SetActive(false);
        pauseButton.SetActive(true);
        mainSound.volume = 0.634f;
    }
    /*IEnumerator MoveTOMenu()
    {

    }*/
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").gameObject;
    }
    void Update()
    {
        if(Player == null)
        {
            StartCoroutine("GameOver");
        }
    }
    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(0.2f);
        pauseButton.SetActive(false);
        score.SetActive(false);
        gameOverPanel.SetActive(true);
        scoreAnim.SetTrigger("ScaleUp");
        scoreTextAnim.SetTrigger("ScaleUp");
        restartButtonAnim2.SetTrigger("ScaleUp");
        homeButtonAnim2.SetTrigger("ScaleUp");
        mainSound.volume = 0.05f;
        //SceneManager.LoadScene("Home");
    }
}
