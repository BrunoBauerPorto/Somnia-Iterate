using UnityEngine;

public class AnimationsLayer : MonoBehaviour
{
    public Animator animLuna;


    public void idleAnim()
    {
        animLuna.SetLayerWeight(1,0f);
        animLuna.SetLayerWeight(0,1f);
    }
}
