using UnityEngine;

public class Hide : MonoBehaviour
{

    public GameObject lunaT;
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            lunaT.tag = "hide";
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("hide"))
        {
            lunaT.tag = "Player";
        }
    }


}
