using UnityEngine;

public class ClowRedSound : MonoBehaviour
{
    public AudioSource note3;
    public static bool redClow = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BallRed"))
        {
            note3.Play();
           // ArcMove.moving = false;
            redClow = true;
            ArcMove.launch = false;
        }
    }
}
