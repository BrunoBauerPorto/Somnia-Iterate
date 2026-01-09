using UnityEngine;

public class CheckBall3 : MonoBehaviour
{
    public static bool owlBlack;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   
        void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if(InventoryPrincipal.ball3 == true)
            {
                Transform children = transform.GetChild(0);
                children.gameObject.SetActive(true);
                GameController2.activeCoruja3 = true; 
            }
            
        }
    }
}
