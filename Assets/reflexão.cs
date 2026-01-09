using UnityEngine;

public class EscudoDestruidor : MonoBehaviour
{
    public GameObject efeitoAoDestruir; // opcional

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Projectile"))
        {
            if (efeitoAoDestruir != null)
            {
                Instantiate(efeitoAoDestruir, other.transform.position, Quaternion.identity);
            }

            Destroy(other.gameObject);
        }
    }
}










