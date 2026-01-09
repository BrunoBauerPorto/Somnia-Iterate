using UnityEngine;

public class LuzPiscaPisca : MonoBehaviour
{

    public bool procurarEmFilhos = true;


    public bool ativo = true;
    public float minTempo = 0.03f;
    public float maxTempo = 0.15f;

    public float intensidadeMin = 0f;
    public float intensidadeMax = 2.5f;


    public bool suavizar = true;
    public float duracaoSuavizacao = 0.04f; 

    public float chanceDesligar = 0.12f; 

    Light luz;
    float timer;
    float targetIntensity;
    float smoothVel;

    void Start()
    {
        luz = GetComponent<Light>();
        if (luz == null && procurarEmFilhos)
            luz = GetComponentInChildren<Light>();

        if (luz == null)
        {
            enabled = false;
            return;
        }

        targetIntensity = luz.intensity;
        GerarNovoTempo();
    }

    void Update()
    {
        if (!ativo || luz == null) return;

        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            if (Random.value < chanceDesligar)
            {
                luz.enabled = !luz.enabled;
            }

            targetIntensity = Random.Range(intensidadeMin, intensidadeMax);

            if (!suavizar)
            {
                luz.intensity = targetIntensity;
            }

            GerarNovoTempo();
        }

        if (suavizar && luz.enabled)
        {
            luz.intensity = Mathf.SmoothDamp(luz.intensity, targetIntensity, ref smoothVel, Mathf.Max(0.0001f, duracaoSuavizacao));
        }
    }

    void GerarNovoTempo()
    {
        timer = Random.Range(minTempo, maxTempo);
    }

}
