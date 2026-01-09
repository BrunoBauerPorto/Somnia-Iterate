using UnityEngine;
using UnityEngine.SceneManagement;

public class Voltando : MonoBehaviour
{


    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            SceneManager.LoadScene("Fase principal");
            ProgressoGeral.fase3Completa = true;
        }
    }
}
