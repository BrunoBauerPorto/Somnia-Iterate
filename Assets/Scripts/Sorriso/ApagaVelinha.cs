using UnityEngine;

public class ApagaVelinha : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Velinha p = other.GetComponent<Velinha>();
            if (p != null)
            {
                p.ApagarVela();
            }
        }
    }
}
    