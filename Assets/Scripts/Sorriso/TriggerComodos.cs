using UnityEngine;
using UnityEngine.AI;

public class TriggerComodos : MonoBehaviour
{
    public GameObject sombra;
    public Transform pontoInicial, spawnSombra;
    public NavMeshAgent agent;

    private bool playerinArea = false;

    private void Start()
    {
        sombra.transform.position = pontoInicial.position;
        sombra.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //playerinArea = true;
            sombra.transform.position = spawnSombra.transform.position;
            sombra.SetActive(true);

            agent.Warp(pontoInicial.position);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //playerinArea = false;
            sombra.SetActive(false);

            agent.Warp(pontoInicial.position);

        }
    }

}
