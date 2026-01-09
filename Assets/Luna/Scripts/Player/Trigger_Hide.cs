using UnityEngine;

public class Trigger_Hide : MonoBehaviour
{
    public GameObject walkButton;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject hideButton;
    
    public Transform luna;

    void Start()
    {
        walkButton.SetActive(false);
        hideButton.SetActive(false);
    }

    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            hideButton.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            hideButton.SetActive(false);
        }
    }



    public void HideControl()
    {
        Luna_Basic.hiding = true;
        hideButton.SetActive(false);
        walkButton.SetActive(true);
    }

    public void Walk()
    {
        walkButton.SetActive(false);
        Luna_Basic.hiding = false;
        Luna_Basic.isWalking = false;
        Luna_Basic.isCrawling = false;
    }
}
