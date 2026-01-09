using System;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Menu : MonoBehaviour
{
    public GameObject Luna;
    public Animator animator;
    public Animator animatorMainCamera;

    void Start()
    {
        animator.Play("mixamo_com");
    }
    public void StartGame()
    {
        SceneManager.LoadScene("TransitionTutorial");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void Setting()
    {
        SceneManager.LoadScene("Setting");
    }

    public void Back()
    {
        SceneManager.LoadScene("Menu");
    }

    public void StartAnimation()
    {
        animatorMainCamera.Play("MenuPlayAnimation");
    }
}
