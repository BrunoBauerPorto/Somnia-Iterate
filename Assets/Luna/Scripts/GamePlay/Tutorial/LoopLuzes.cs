using UnityEngine;
using System.Collections;

public class MenuLoop : MonoBehaviour
{
    public Animator animator;
    public string [] animationStateName;
    public float delayBetweenLoops = 2f;

    public float RandomDelayVariation = 3f;

    private int lastAnimationIndex = -1;

    void Start()
    {
        if (animator == null)
        {
            Debug.LogError("Animator não atribuído!");
            return;
        }

        if (animationStateName == null || animationStateName.Length == 0)
        {
            Debug.LogError("Nenhuma animação configurada!");
            return;
        }

        StartCoroutine(LoopRandomAnimations());
    }
   IEnumerator LoopRandomAnimations()
    {
        while (true)
        {
           
            int index;
            do
            {
                index = Random.Range(0, animationStateName.Length);
            } while (index == lastAnimationIndex && animationStateName.Length > 1);

            lastAnimationIndex = index;
            string chosenState = animationStateName[index];

            // Tocar animação
            Debug.Log("Tocando animação: " + chosenState);
            animator.Play(chosenState, 0, 0f);

            // Esperar a duração da animação + delay aleatório
            yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);

            float randomDelay = delayBetweenLoops + Random.Range(-RandomDelayVariation, RandomDelayVariation);
            yield return new WaitForSeconds(randomDelay);
        }
        }
    }
