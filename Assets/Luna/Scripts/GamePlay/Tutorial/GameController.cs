using UnityEngine;

public class GameController : MonoBehaviour
{
    public static bool openCabinet;

    public GameObject keyCam;
    public GameObject mainCam;
    public GameObject dialogue2;

    public AudioSource floorHitKey;

    public Rigidbody key;

    bool endingTriggered = false;
    bool dialogueWasActive = false;

    void Start()
    {
        openCabinet = false;
        keyCam.SetActive(false);
        mainCam.SetActive(true);
    }

    void Update()
    {
        // Dispara o final UMA vez
        if (!endingTriggered &&
            Object1.object1 &&
            Object2.object2 &&
            Object3.object3)
        {
            endingTriggered = true;

            openCabinet = true;
            key.isKinematic = false;

            dialogue2.SetActive(true);
            dialogueWasActive = true;

            mainCam.SetActive(false);
            keyCam.SetActive(true);

            floorHitKey.Play();
        }

        // Detecta quando o diálogo terminou
        if (dialogueWasActive && !dialogue2.activeSelf)
        {
            dialogueWasActive = false;

            keyCam.SetActive(false);
            mainCam.SetActive(true);
        }
    }
}
