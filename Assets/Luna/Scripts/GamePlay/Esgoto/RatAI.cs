using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class RatAI : MonoBehaviour
{
    //public AudioSource asas, audioSource;
    //public AudioClip attack;
    //public GameObject gameOver;
    private NavMeshAgent agent;
    public bool isAttacking;

    // Referência ao player
    private Transform player;

    // Distância mínima para parar perto do player
    public float stoppingDistance = 0f;

    public Transform target;
    public float speed = 2f;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        isAttacking = false;


        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            player = playerObj.transform;
        }


        // Ajusta a distância de parada
        if (agent != null)
            agent.stoppingDistance = stoppingDistance;
        //asas.Play();
    }

    void Update()
    {

        if (agent == null || player == null)
            return;

        agent.SetDestination(player.position);

        float distance = Vector3.Distance(transform.position, player.position);
        if (distance <= stoppingDistance)
        {
            agent.isStopped = true;
        }
        else
        {
            agent.isStopped = false;
        }

        /*if (distance <= 5f)
        {
            audioSource.PlayOneShot(attack);
        }*/

        Vector3 direction = target.position - transform.position;

        // Se existe alguma direção para olhar
        if (direction != Vector3.zero)
        {
            // Rotação desejada
            Quaternion desiredRotation = Quaternion.LookRotation(direction);

            // Rotação suave
            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                desiredRotation,
                speed * Time.deltaTime
            );
        }





    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene("Esgoto");
        }

    }
}
