using UnityEngine;
using UnityEngine.SceneManagement;

public class DieSewer : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Player"))
        {
            SceneManager.LoadScene("TransitionEsgoto");
        }
    }
}
