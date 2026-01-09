using UnityEngine;

public class MoveBox : MonoBehaviour
{
    public float pushSpeed = 2f;
    public string empurravelTag = "Empurravel";

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag(empurravelTag))
        {
            // Calcula direção do empurrão
            Vector3 direction = (other.transform.position - transform.position).normalized;
            direction.y = 0; // ignora altura

            // Move o objeto empurrado
            other.transform.position += direction * pushSpeed * Time.deltaTime;
        }
    }
}
