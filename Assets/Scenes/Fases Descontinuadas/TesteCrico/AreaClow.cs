using UnityEngine;

public class AreaClow : MonoBehaviour
{
    public GameObject joyStick, clows;
    public Camera mainCamera, cameraClow;
    public Animator animLuna;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        clows.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if(InventoryCircus.ball1 == true || InventoryCircus.ball2 == true || InventoryCircus.ball3 == true )
            {
                clows.SetActive(true);
               // mainCamera.depth = 0;
               //cameraClow.depth = 5;
                //Luna_Basic.velocity = 0;
                animLuna.SetLayerWeight(0,0);
                animLuna.SetLayerWeight(1,0);
                animLuna.SetLayerWeight(2,0);
                animLuna.SetLayerWeight(3,1);
            }
            else{clows.SetActive(false);}
        }
    }*/

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (InventoryCircus.ball1 == true || InventoryCircus.ball2 == true || InventoryCircus.ball3 == true)
            {
                clows.SetActive(true);
                // mainCamera.depth = 0;
                //cameraClow.depth = 5;
                //Luna_Basic.velocity = 0;
                animLuna.SetLayerWeight(0, 0);
                animLuna.SetLayerWeight(1, 0);
                animLuna.SetLayerWeight(2, 0);
                animLuna.SetLayerWeight(3, 1);
            }
            else { clows.SetActive(false); }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            clows.SetActive(false);
            animLuna.SetLayerWeight(0, 1);
            animLuna.SetLayerWeight(1, 0);
            animLuna.SetLayerWeight(2, 0);
            animLuna.SetLayerWeight(3, 0);
        }
        
    }
}
