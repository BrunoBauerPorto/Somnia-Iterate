using UnityEngine;

public class SemVolta : MonoBehaviour
{
    public Collider colliderParaAtivar;
    public Collider Portal;
    public static bool semVolta = false;

    public AudioSource somTranca;
    public AudioClip trancando;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            colliderParaAtivar.enabled = true;
            Portal.enabled = true;
            if (somTranca != null && trancando != null)
                somTranca.PlayOneShot(trancando);

            gameObject.SetActive(false);
        }
    }
}
