using System;
using UnityEngine;

public class Key : MonoBehaviour
{
    public Rigidbody key;
    public GameObject keyInteract;
   

    

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("floor"))
        {
           
            keyInteract.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
