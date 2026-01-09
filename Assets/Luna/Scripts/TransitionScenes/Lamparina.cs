using UnityEngine;
using UnityEngine.SceneManagement;

public class Lamparina : MonoBehaviour
{
    public string scenename;
    public float timer = 0;
    public float delay;
    

    
    void Update()
    {
        if (timer>=delay)
        {
            SceneManager.LoadScene(scenename);
            timer = 0;
        }
        timer += Time.deltaTime;
    }
}
