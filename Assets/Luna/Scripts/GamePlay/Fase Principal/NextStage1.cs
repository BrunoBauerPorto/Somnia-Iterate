using UnityEngine;
using UnityEngine.SceneManagement;
public class NextStage1 : MonoBehaviour
{
    public string scene;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            SceneManager.LoadScene(scene);
        }
    }

}
