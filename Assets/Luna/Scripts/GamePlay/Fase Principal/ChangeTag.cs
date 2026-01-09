using UnityEngine;

public class ChangeTag : MonoBehaviour
{
    public GameObject tronco, troncoInteract, rato;

    
    public void EndAnimation()
    {
        troncoInteract.SetActive(true);
        Destroy(rato);
        Destroy(tronco);
        troncoInteract.SetActive(true);
        troncoInteract.tag = "Pickup";
        
    }
}
