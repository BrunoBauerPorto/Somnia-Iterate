using UnityEngine;
using UnityEngine.SceneManagement;
public class Door : MonoBehaviour
{
    public AudioSource HandleDoor;
    public string scenename;
   

    void PlayHandle()
    {
        HandleDoor.Play();
    }
    void EndAnimation()
    {
        SceneManager.LoadScene(scenename);
    }
}
