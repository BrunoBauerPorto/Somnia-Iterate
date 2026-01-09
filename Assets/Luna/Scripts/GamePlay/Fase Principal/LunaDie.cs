using UnityEngine;
using UnityEngine.SceneManagement;

public class LunaDie : MonoBehaviour
{
    public string nameStage;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            SceneManager.LoadScene(nameStage);
        }
    }
}
