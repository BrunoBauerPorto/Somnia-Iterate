using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{

    public GameObject painelPause;
    public GameObject pauseButton;
    public GameObject inGameUI;
    public string nextScene;
    

    private bool isPaused = false;
    [SerializeField] LeanTweenType loopType;

void Start()
    {
        LeanTween.init();
    }
     public void GamePause()
    {
        isPaused = true;
        Time.timeScale = 0f;

        pauseButton.SetActive(false);
        painelPause.SetActive(true);
        inGameUI.SetActive(false);
    }
    
    public void ContinuaGame()
    {
        isPaused = false;
        Time.timeScale = 1.0f;

        pauseButton.SetActive(true);
        painelPause.SetActive(false);
        inGameUI.SetActive(true);
    }

    public void BackMenu()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1f;
    }

    public void NextScene()
    {
        SceneManager.LoadScene(nextScene);

         isPaused = false;
        Time.timeScale = 1.0f;

        pauseButton.SetActive(true);
        painelPause.SetActive(false);
        inGameUI.SetActive(true);
    }

}
