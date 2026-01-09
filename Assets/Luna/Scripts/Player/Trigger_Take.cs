using UnityEngine;

public class Trigger_Take : MonoBehaviour
{
    public GameObject buttonTaking;
    
    public Animator animLuna;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        buttonTaking.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            buttonTaking.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            buttonTaking.SetActive(false);
        }
    }

    public void TakingAnim()
    {
        animLuna.SetTrigger("Taking");
        buttonTaking.SetActive(false);
        AnimTakeControl.isTaking = true;
    }


}
