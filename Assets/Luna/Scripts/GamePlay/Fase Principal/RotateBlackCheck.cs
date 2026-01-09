using UnityEngine;

public class RotateBlackCheck : MonoBehaviour
{


    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("checkBlack"))
        {
            GameController2.corujaBlackCheck = true;
        }
    }
}
