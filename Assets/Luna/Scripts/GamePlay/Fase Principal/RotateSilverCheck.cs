using UnityEngine;

public class RotateSilverCheck : MonoBehaviour
{


    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("checkSilver"))
        {
            GameController2.corujaSilverCheck = true;
        }
    }
}
