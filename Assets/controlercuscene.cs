using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class CutsceneMonitor2 : MonoBehaviour
{
    public PlayableDirector cutscene; // Arraste aqui o seu TimelineFase4 na Unity

    void Update()
    {
        if (cutscene != null && cutscene.state != PlayState.Playing)
        {
            SceneManager.LoadScene("Fase5");
        }
    }
}
