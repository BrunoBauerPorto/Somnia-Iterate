using UnityEngine;

public class VejaOquadro : MonoBehaviour
{

    public GameObject botaoFocar;       

    public GameObject botaoSair;        

    public GameObject quadroCanvas;     

    public GameObject inventarioCanvas;  

    public GameObject joystickCanvas; 


    public bool fechaAoSair = true;


    private void Start()
    {
        if (botaoFocar) botaoFocar.SetActive(false);
        if (botaoSair) botaoSair.SetActive(false);
        if (quadroCanvas) quadroCanvas.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        
            if (botaoFocar) botaoFocar.SetActive(true);
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!other.CompareTag("Player")) return;


            if (botaoFocar) botaoFocar.SetActive(false);


            if (fechaAoSair && quadroCanvas && quadroCanvas.activeSelf)
            {
                FecharQuadro();
            }
        }
    }

    public void AbrirQuadro()
    {
        if (quadroCanvas) quadroCanvas.SetActive(true);
        if (botaoFocar) botaoFocar.SetActive(false);
        if (botaoSair) botaoSair.SetActive(true);


        if (inventarioCanvas) inventarioCanvas.SetActive(false);
        if (joystickCanvas) joystickCanvas.SetActive(false);
    }
    public void FecharQuadro()
    {
        if (quadroCanvas) quadroCanvas.SetActive(false);
        if (botaoSair) botaoSair.SetActive(false);


        if (botaoFocar) botaoFocar.SetActive(true);


        if (inventarioCanvas) inventarioCanvas.SetActive(true);
        if (joystickCanvas) joystickCanvas.SetActive(true);
    }

}
