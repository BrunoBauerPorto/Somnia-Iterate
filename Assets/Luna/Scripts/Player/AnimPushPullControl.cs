using UnityEngine;

public class AnimPushPullControl : MonoBehaviour
{
    public Animator animLuna;


    public void OnPushPull()
    {
        animLuna.SetTrigger("OnPull");
        Trigger_PushPull.onPushPull = true;
        

    }

    public void OutPushPull()
    {
        animLuna.SetTrigger("OutPull");
        Trigger_PushPull.onPushPull = false;
        
    }

    public void StartPushPull()
    {
        Luna_Basic.isHolding = true;
    }

    public void EndPushPull()
    {
        Luna_Basic.isHolding = false;
    }
}
