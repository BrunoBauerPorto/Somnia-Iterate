using UnityEngine;

public class AreaEscura : MonoBehaviour
{

    public SorrisoS monster;
    private bool playerInArea = false;
    private Velinha playerVelinha;
    public ParticleSystem darkParticles;

    public AudioSource audioSource;
    public AudioClip coraçãoBatendo;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInArea = true;
            darkParticles.Play();

            playerVelinha = other.GetComponent<Velinha>();

            if (audioSource != null && coraçãoBatendo != null)
            {
                audioSource.clip = coraçãoBatendo;
                audioSource.loop = true;
                audioSource.Play();
            }

            CheckLight();
        }
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(playerInArea)
                CheckLight();
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInArea = false;
            monster.StopChasing();
            darkParticles.Stop();
            audioSource.Stop();
        }
    }

    void CheckLight()
    {
        if (playerVelinha == null) return;

        if (!playerVelinha.lightOn)
        {
            monster.StartChasing();
        }
        else
        {
            monster.StopChasing();
        }

    }


}
