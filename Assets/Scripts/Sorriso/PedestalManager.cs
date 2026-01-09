using UnityEngine;

public class PedestalManager : MonoBehaviour
{
    public static PedestalManager Instance;

    public Pedestal[] pedestais;
    public GameObject objetoParaAparecer;

    private void Awake()
    {
        Instance = this;

        if (objetoParaAparecer != null)
            objetoParaAparecer.SetActive(false);
    }

    public void CheckPedestals()
    {
        foreach (var p in pedestais)
        {
            if (!p.preenchido)
            {
                return;
            }
        }

        objetoParaAparecer.SetActive(true);
    }
}
