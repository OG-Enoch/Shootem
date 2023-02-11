using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public Animator settingsAnim;
    public Animator transitionAnim;
    public GameObject settingsButton;
    
    public void Settings()
    {
        settingsAnim.SetTrigger("ScaleUp");
        settingsButton.SetActive(false);
    }
    public void CloseSettings()
    {
        settingsAnim.SetTrigger("ScaleDown");
        settingsButton.SetActive(true);
    }

    public void Game()
    {
        StartCoroutine(GoToScene());
    }

    IEnumerator GoToScene()
    {
        transitionAnim.SetTrigger("TransitionStart");
        yield return new WaitForSeconds(0.5f);
        transitionAnim.SetTrigger("TransitionEnd");
        SceneManager.LoadScene("Game");
    }
}
