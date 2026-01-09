using UnityEngine;
using System.Collections;

public class DisableJoystick : MonoBehaviour
{
    public GameObject JoyStick, Dialogue;
    public float timer = 0;
    public float delay;
   
    void Start()
    {
        JoyStick.SetActive(false);
       

    }

    
    void Update()
    {
        if (timer>=delay)
        {
             Dialogue.SetActive(true);
             timer = 0;
        }
        timer += Time.deltaTime;
    }
}
