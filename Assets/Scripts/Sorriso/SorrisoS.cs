using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class SorrisoS : MonoBehaviour
{
    public Transform player;
    public NavMeshAgent agent;
    public Transform Camera;
    public GameObject gameOver;

    public AudioSource audioSource;
    public AudioClip Caçando;

    private bool isChasing = false;

    public void StartChasing()
    {
        if (agent == null || !agent.enabled || !agent.isOnNavMesh || !gameObject.activeInHierarchy)
            return;

        if (!isChasing)
        {
            isChasing = true;

            audioSource.clip = Caçando;
            audioSource.loop = true;
            audioSource.Play();

        }

        agent.SetDestination(player.position);
    }

    public void StopChasing()
    {
        if (agent == null || !agent.enabled || !agent.isOnNavMesh || !gameObject.activeInHierarchy)
            return;

        if (isChasing)
        {
            isChasing = false;
            audioSource.Stop();
        }


        agent.ResetPath();
    }

    void Update()
    {
        if (Camera != null)
            transform.LookAt(Camera);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            gameOver.SetActive(true);
            SceneManager.LoadScene("Fase Sombra");
        }
    }
}
