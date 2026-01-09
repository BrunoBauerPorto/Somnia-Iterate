using UnityEngine;

public class ActiveRat : MonoBehaviour
{
    public GameObject rat;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            rat.GetComponent<RatAI>().enabled = true;
        }
    }
}
