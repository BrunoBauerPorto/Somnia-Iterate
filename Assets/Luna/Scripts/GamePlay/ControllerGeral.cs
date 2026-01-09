using UnityEngine;

public class ControllerGeral : MonoBehaviour
{
    public static ControllerGeral Instance;

    public static bool fase1Completa = false;
    public static bool fase2Completa = false;
    public static bool fase3Completa = false;
    public static bool fase4Completa = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
