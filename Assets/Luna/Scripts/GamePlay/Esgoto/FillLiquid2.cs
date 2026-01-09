using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FillLiquid2 : MonoBehaviour
{
    [Header("Material com o Float _Fill")]
    public Material material;    // A
    public Material material2;   // B (inverso)
    private const string fillProperty = "_Fill";

    [Header("Configurações")]
    public float step = 1f / 3f;
    public float animationDuration = 0.4f;

    [Header("Botões")]
    public Button botaoEsquerda;
    public Button botaoDireita;

    private Coroutine routineA, routineB;

    private void Start()
    {
        botaoEsquerda.onClick.AddListener(() => Move(-step)); // A desce, B sobe
        botaoDireita.onClick.AddListener(() => Move(step));   // A sobe, B desce
    }

    private void Move(float amount)
    {
        float aCurrent = material.GetFloat(fillProperty);
        float bCurrent = material2.GetFloat(fillProperty);

        float aTarget = aCurrent + amount;
        float bTarget = bCurrent - amount; // inverso

        // 🚫 Se qualquer um ultrapassar 0–1 → nenhum se move
        if (aTarget < 0f || aTarget > 1f || bTarget < 0f || bTarget > 1f)
            return;

        // Clamp
        aTarget = Mathf.Clamp01(aTarget);
        bTarget = Mathf.Clamp01(bTarget);

        // Anima A
        if (routineA != null)
            StopCoroutine(routineA);
        routineA = StartCoroutine(Animate(material, aCurrent, aTarget));

        // Anima B
        if (routineB != null)
            StopCoroutine(routineB);
        routineB = StartCoroutine(Animate(material2, bCurrent, bTarget));
    }

    private IEnumerator Animate(Material mat, float start, float end)
    {
        float t = 0f;

        while (t < animationDuration)
        {
            t += Time.deltaTime;
            float lerp = Mathf.Lerp(start, end, t / animationDuration);
            mat.SetFloat(fillProperty, lerp);
            yield return null;
        }

        mat.SetFloat(fillProperty, end);
    }
}
