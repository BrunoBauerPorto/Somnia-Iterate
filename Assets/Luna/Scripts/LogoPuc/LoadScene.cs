using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneAfterTime : MonoBehaviour
{
    [SerializeField]
    private float tempoCarregar = 10f;
    [SerializeField]
    private string nomeCena;
    private float timeElapsed;
    private float delayBeforeLoading;

   

    private void Update()
    {
        timeElapsed += Time.deltaTime;

        if (timeElapsed > tempoCarregar)
        {
            SceneManager.LoadScene(nomeCena);
        }
    }
}