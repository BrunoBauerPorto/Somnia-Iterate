using UnityEngine;

public class RotateGoldenCheck : MonoBehaviour
{


    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("checkGolden"))
        {
            GameController2.corujaGoldenCheck = true;
        }
    }
}
