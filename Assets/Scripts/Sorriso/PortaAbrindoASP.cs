using UnityEngine;

public class PortaAbrindoASP : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip somAbrindo;

    public float somDalay = 3f;
    public bool podeTocar = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && podeTocar)
        {
            TocarComDelay();
        }
    }

    private void TocarComDelay()
    {   
        if (audioSource != null && somAbrindo != null)
            audioSource.PlayOneShot(somAbrindo);

        podeTocar = false;
        Invoke(nameof(ResetarPodeTocar), somDalay);
    }

    private void ResetarPodeTocar()
    {
        podeTocar = true;
    }

    
}
