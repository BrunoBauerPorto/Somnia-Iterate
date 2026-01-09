using UnityEngine;

public class ClowOrangeSound : MonoBehaviour
{

    public AudioSource note1;
    public static bool orangeClow = false;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("BallOrange"))
        {
            note1.Play();
           // ArcMove.moving = false;
            orangeClow = true;
            ArcMove.launch = false;
        }
    }
}
