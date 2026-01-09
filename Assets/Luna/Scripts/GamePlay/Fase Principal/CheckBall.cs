using System;
using UnityEngine;

public class CheckBall : MonoBehaviour
{
    


    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if(InventoryPrincipal.ball1== true)
            {
                Transform children = transform.GetChild(0);
                children.gameObject.SetActive(true);
                GameController2.activeCoruja1 = true;    
            }
            
        }
    }
}
