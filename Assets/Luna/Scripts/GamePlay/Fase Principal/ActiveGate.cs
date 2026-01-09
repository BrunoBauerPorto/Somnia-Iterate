using UnityEngine;

public class ActiveGate : MonoBehaviour
{
    public GameObject button, gate;
    
    public Camera camMain, camInit;

    public Animator owl;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        camMain.depth = 5;
        camInit.depth = 1;
    }

   

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Empurravel"))
        {
            button.GetComponent<Animator>().enabled = true;
            gate.GetComponent<Animator>().enabled = true;
            camInit.depth = 5;
            camMain.depth = 1;
            owl.SetTrigger("Voo");
            
        }
    }
}
