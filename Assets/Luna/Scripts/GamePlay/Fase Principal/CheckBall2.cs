using UnityEngine;

public class CheckBall2 : MonoBehaviour
{

    
        void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if(InventoryPrincipal.ball2 == true)
            {
                Transform children = transform.GetChild(0);
                children.gameObject.SetActive(true);
                GameController2.activeCoruja2 = true; 
            }
            
        }
    }
}
