using UnityEngine;
using UnityEngine.AI;

public class EnemyNav : MonoBehaviour
{
    public AudioSource asas, audioSource;
    public AudioClip attack;
    private NavMeshAgent agent;

    public bool isAttacking;
    public static bool gameOver = false;

    private Transform player;
    public float stoppingDistance = 0f;

    public Transform target;
    public float speed = 2f;

    // --- Patrulha aleatória ---
    public float wanderRadius = 10f; // área onde pode andar
    public float wanderTimer = 5f;   // tempo até escolher novo destino
    private float timer;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        isAttacking = false;

        TryFindPlayer(); // tenta achar um player inicialmente

        if (agent != null)
            agent.stoppingDistance = stoppingDistance;

        timer = wanderTimer;

        if (asas != null)
            asas.Play();
    }

    void Update()
    {
        // se o player atual perdeu a tag "Player" ou é null, tenta encontrar outro
        if (player == null || (player != null && !player.CompareTag("Player")))
        {
            TryFindPlayer();
        }

        // Se não tem Player (não encontrado), patrulha aleatoriamente
        if (player == null)
        {
            Wandering();
            return; // não executa perseguição
        }

        // --- Comportamento normal se o Player existe ---
        if (agent != null)
            agent.SetDestination(player.position);

        float distance = Vector3.Distance(transform.position, player.position);

        if (agent != null)
        {
            agent.isStopped = (distance <= stoppingDistance);
        }

        if (distance <= 5f)
        {
            if (!isAttacking)
            {
                if (audioSource != null && attack != null)
                    audioSource.PlayOneShot(attack);
                isAttacking = true;
            }
        }
        else isAttacking = false;

        // Olhar para o target (se existir)
        if (target != null)
        {
            Vector3 direction = target.position - transform.position;
            if (direction != Vector3.zero)
            {
                Quaternion desiredRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, speed * Time.deltaTime);
            }
        }
    }

    // Tenta encontrar o jogador válido. Se houver vários, escolhe o mais próximo.
    void TryFindPlayer()
    {
        GameObject[] candidates = GameObject.FindGameObjectsWithTag("Player");
        if (candidates == null || candidates.Length == 0)
        {
            player = null;
            return;
        }

        // seleciona o candidato mais próximo
        Transform best = null;
        float bestDist = float.MaxValue;
        foreach (var go in candidates)
        {
            float d = Vector3.SqrMagnitude(go.transform.position - transform.position);
            if (d < bestDist)
            {
                bestDist = d;
                best = go.transform;
            }
        }

        player = best;
    }

    // Função de movimento aleatório
    void Wandering()
    {
        if (agent == null) return;

        timer += Time.deltaTime;

        // Quando o timer "zera", escolhe novo destino
        if (timer >= wanderTimer)
        {
            Vector3 newPos = RandomNavSphere(transform.position, wanderRadius);
            agent.SetDestination(newPos);
            timer = 0;
        }
    }

    // Gera posição aleatória válida dentro do NavMesh
    public static Vector3 RandomNavSphere(Vector3 origin, float dist)
    {
        Vector3 randDirection = Random.insideUnitSphere * dist;
        randDirection += origin;

        NavMeshHit navHit;
        NavMesh.SamplePosition(randDirection, out navHit, dist, NavMesh.AllAreas);

        return navHit.position;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            gameOver = true;
    }
}
