using UnityEngine;

public class ClowGreenSound : MonoBehaviour
{
    public AudioSource note2;
    public static bool greenClow = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BallGreen"))
        {
            note2.Play();
           // ArcMove.moving = false;
            greenClow = true;
            ArcMove.launch = false;
        }
    }
}
