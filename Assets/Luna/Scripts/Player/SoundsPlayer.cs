using UnityEngine;

public class SoundsPlayer : MonoBehaviour
{
    public AudioSource step, grassStep;



    public void Step()
    {
        if(SemVolta.semVolta == true)
        {
            grassStep.Play();
        }
        else
        {
            step.Play();
        }
            
    }
}
