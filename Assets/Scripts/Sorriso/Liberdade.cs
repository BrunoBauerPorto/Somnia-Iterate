using System.Collections;
using UnityEngine;

public class Liberdade : MonoBehaviour
{
    public Collider colliderSemVolta;

    public int itemID = 666;

    public AudioSource audioSource;
    public AudioClip destrancando;

    private void Update()
    {

        if (InventarioFaseSombra.Instance.TemItem(itemID))
        {
            colliderSemVolta.isTrigger = true;

            StartCoroutine(SomComDelay());

            enabled = false;
        }
    }

    private IEnumerator SomComDelay()
    {
        yield return new WaitForSeconds(3.5f);
        audioSource.PlayOneShot(destrancando);
    }

}
