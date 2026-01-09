using System.Collections;
using UnityEngine;

public class Velinha : MonoBehaviour
{
    public bool lightOn = true;
    public float tempoParaAcender = 15f;

    public AudioSource audioSource;
    public AudioClip somApagarVela;

    public GameObject luz;

    private bool recarregando = false;

    public void ApagarVela()
    {
        if (!lightOn || recarregando ) return;

        lightOn = false;

        if (audioSource != null && somApagarVela != null)
        {
            audioSource.PlayOneShot(somApagarVela);
        }

        recarregando = true;
        luz.SetActive(false);

        StartCoroutine(RecarregarVela());
    }

    IEnumerator RecarregarVela()
    {
        yield return new WaitForSeconds(tempoParaAcender);
        lightOn = true;
        recarregando = false;
        luz.SetActive(true);
    }
}
