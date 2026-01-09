using UnityEngine;

public class AnimationRat : MonoBehaviour
{
    public GameObject rat, box;
   

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Pickup"))
        {
            box.tag = "Empurravel";
            rat.GetComponent<Animator>().enabled = true;
            Destroy(gameObject, 0.1f);
            
        }
    }
}
