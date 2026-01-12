using UnityEngine;

public class GameController : MonoBehaviour
{
    private enum CameraState
    {
        FollowPlayer,
        MoveToDialogue,
        Dialogue
    }

    private CameraState camState = CameraState.FollowPlayer;

    [Header("Camera")]
    [SerializeField] private GameObject camMain;
    [SerializeField] private GameObject camKey;
    [SerializeField] private Transform mainCamPos;
    [SerializeField] private Transform keyCamPos;
    [SerializeField] private float camMoveSpeed = 3f;

    [Header("Dialogue")]
    [SerializeField] private GameObject dialogue2;

    [Header("Gameplay")]
    public static bool openCabinet;
    [SerializeField] private Rigidbody key;
    [SerializeField] private AudioSource floorHitKey;

    private bool endingTriggered = false;
    private bool dialogueWasActive = false;

    void Start()
    {
        openCabinet = false;
        SetCameraState(CameraState.FollowPlayer);
    }

    void Update()
    {
        UpdateCamera();
        HandleEnding();
    }

    
    // CAMERA LOGIC
   
    void UpdateCamera()
    {
        switch (camState)
        {
            case CameraState.FollowPlayer:
                
                break;

            case CameraState.MoveToDialogue:
                camKey.transform.position = Vector3.Lerp(
                    camKey.transform.position,
                    keyCamPos.position,
                    camMoveSpeed * Time.deltaTime
                );

                if (Vector3.Distance(camKey.transform.position, keyCamPos.position) < 0.05f)
                {
                    camKey.transform.position = keyCamPos.position;
                    SetCameraState(CameraState.Dialogue);
                }
                break;

            case CameraState.Dialogue:
                
                break;
        }
    }

    void SetCameraState(CameraState newState)
    {
        camState = newState;

        camMain.SetActive(newState == CameraState.FollowPlayer);
        camKey.SetActive(newState != CameraState.FollowPlayer);
    }

    
    // ENDING / EVENT LOGIC
   
    void HandleEnding()
    {
        if (!endingTriggered &&
            Object1.object1 &&
            Object2.object2 &&
            Object3.object3)
        {
            TriggerEnding();
        }

        
        if (dialogueWasActive && dialogue2 != null && !dialogue2.activeSelf)
        {
            dialogueWasActive = false;
            SetCameraState(CameraState.FollowPlayer);
        }
    }

    void TriggerEnding()
    {
        endingTriggered = true;

        SetCameraState(CameraState.MoveToDialogue);

        openCabinet = true;

        if (key != null)
            key.isKinematic = false;

        if (dialogue2 != null)
        {
            dialogue2.SetActive(true);
            dialogueWasActive = true;
        }

        if (floorHitKey != null)
            floorHitKey.Play();
    }
}
