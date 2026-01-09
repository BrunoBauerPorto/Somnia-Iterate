using System.Data.SqlTypes;
using UnityEngine;

public class PushBox : MonoBehaviour
{
    public float pushForce = 5f;

    void OnTriggerStay(Collider other)
    {
        // Pega o Rigidbody do objeto que FOI COLIDIDO
        Rigidbody rb = other.GetComponent<Rigidbody>();

        if (rb != null)
        {
            // Direção Z mundial (0,0,1)
            Vector3 direction = transform.forward;


            // Aplica a força
            rb.AddForce(direction * pushForce, ForceMode.Impulse);
        }
    }
}
